using AssetRipper.Import.Logging;
using Newtonsoft.Json.Linq;
using Scriban.Functions;
using YamlDotNet.Serialization;

namespace AssetRipper.Export.UnityProjects.Scripts
{
	public class ResourceDistinct : IPostExporter
	{
		public void DoPostExport(Ripper ripper)
		{
			string root = Path.Combine(ripper.Settings.ProjectRootPath, "Assets");
			int count;
			do
			{
				Dictionary<string, List<string>> filesByName = new();

				foreach (string file in Directory.GetFiles(root, "*", SearchOption.AllDirectories))
				{
					if (!file.EndsWith(".meta"))
					{
						string name = Path.GetFileName(file);
						if (filesByName.TryGetValue(name, out List<string>? lst))
						{
							lst.Add(file);
						}
						else
						{
							lst = new List<string> { file };
							filesByName.Add(name, lst);
						}
					}
				}


				List<(string NewGuid, string OldGuid)> guids = new();

				foreach (KeyValuePair<string, List<string>> entry in filesByName.Where(kv => kv.Value.Count > 1))
				{
					List<string> files = entry.Value;

					List<string> metaFiles = files.Select(f => f + ".meta").ToList();

					var metaGroups = metaFiles.GroupBy(
							file => string.Join(Environment.NewLine, File.ReadAllLines(file).Skip(4)),
							(key, groupFiles) => new { Content = key, Files = groupFiles.ToList() })
						.Where(group => group.Files.Count > 1);


					foreach (var group in metaGroups)
					{
						Dictionary<string, List<string>> fileGroups = new();

						foreach (string metaFile in group.Files)
						{
							string resFile = RemoveSuffix(metaFile, ".meta");
							string md5 = StringFunctions.Md5(File.ReadAllText(resFile));

							if (fileGroups.TryGetValue(md5, out List<string>? lst))
							{
								lst.Add(resFile);
							}
							else
							{
								lst = new List<string> { resFile };
								fileGroups.Add(md5, lst);
							}
						}

						foreach (KeyValuePair<string, List<string>> kv in fileGroups)
						{
							List<string> resFiles = kv.Value;
							resFiles.Sort();

							if (resFiles.Count > 1)
							{
								ReadMeta(resFiles[0], out string newGuid);

								foreach (string resFile in resFiles.Skip(1))
								{
									JObject meta = ReadMeta(resFile, out string oldGuid);
									string? assetBundleName = meta.SelectToken(".NativeFormatImporter.assetBundleName")
										?.Value<string>();
									if (!string.IsNullOrEmpty(assetBundleName)) // ab里面的资源有可能会被动态加载,暂时忽略吧
									{
										continue;
									}

									guids.Add((newGuid, oldGuid));
									Logger.Info($"delete: {resFile} GUID {oldGuid} -> {newGuid}");

									File.Delete(resFile);
									File.Delete(resFile + ".meta");
								}
							}
						}
					}
				}

				count = ReplaceGuids(root, guids);
			} while (count > 0);

			// 删除所有空目录
			DirectoryInfo dir = new(root);
			DirectoryInfo[] subDirs = dir.GetDirectories("*.*", SearchOption.AllDirectories);
			foreach (DirectoryInfo subDir in subDirs)
			{
				if (subDir.Exists)
				{
					FileSystemInfo[] subFiles = subDir.GetFileSystemInfos();
					if (!subFiles.Any())
					{
						subDir.Delete();
					}
				}
			}
		}

		private static int ReplaceGuids(string root, List<(string NewGuid, string OldGuid)> guids)
		{
			int count = 0;

			List<string> resFiles = new();

			resFiles.AddRange(Directory.GetFiles(root, "*.asset", SearchOption.AllDirectories));
			resFiles.AddRange(Directory.GetFiles(root, "*.anim", SearchOption.AllDirectories));
			resFiles.AddRange(Directory.GetFiles(root, "*.controller", SearchOption.AllDirectories));
			resFiles.AddRange(Directory.GetFiles(root, "*.spriteatlas", SearchOption.AllDirectories));
			resFiles.AddRange(Directory.GetFiles(root, "*.prefab", SearchOption.AllDirectories));
			resFiles.AddRange(Directory.GetFiles(root, "*.unity", SearchOption.AllDirectories));
			resFiles.AddRange(Directory.GetFiles(root, "*.overrideController", SearchOption.AllDirectories));
			resFiles.AddRange(Directory.GetFiles(root, "*.mixer", SearchOption.AllDirectories));
			resFiles.AddRange(Directory.GetFiles(root, "*.mask", SearchOption.AllDirectories));
			resFiles.AddRange(Directory.GetFiles(root, "*.physicMaterial", SearchOption.AllDirectories));
			resFiles.AddRange(Directory.GetFiles(root, "*.physicsMaterial2D", SearchOption.AllDirectories));

			foreach (string resFile in resFiles)
			{
				string content = File.ReadAllText(resFile);
				bool change = false;

				foreach ((string NewGuid, string OldGuid) tuple in guids)
				{
					string newContent = content.Replace(tuple.OldGuid, tuple.NewGuid);

					if (!ReferenceEquals(content, newContent))
					{
						change = true;
					}

					content = newContent;
				}

				if (change)
				{
					count++;
					Logger.Info($"replace guid: {resFile}");
					File.WriteAllText(resFile, content);
				}
			}

			return count;
		}

		private static JObject ReadMeta(string resFile, out string guid)
		{
			IDeserializer deserializer = new DeserializerBuilder().Build();
			dynamic meta = deserializer.Deserialize<dynamic>(File.ReadAllText(resFile + ".meta"));
#pragma warning disable IL2026
			JObject json = JObject.FromObject(meta);
#pragma warning restore IL2026

			string? g = json.Value<string>("guid");
			if (string.IsNullOrEmpty(g))
			{
				throw new Exception($"guid not found. {resFile}");
			}

			guid = g;
			return json;
		}

		public static string RemoveSuffix(string str, string suffix)
		{
			if (str.EndsWith(suffix))
			{
				return str.Remove(str.Length - suffix.Length);
			}

			return str;
		}

		private static string RemoveFirstNLines(string text, int n)
		{
			string[] lines = text.Split(Environment.NewLine);
			return string.Join(Environment.NewLine, lines.Skip(n));
		}
	}
}
