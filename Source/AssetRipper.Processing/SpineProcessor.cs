using AssetRipper.Assets;
using AssetRipper.Assets.Bundles;
using AssetRipper.Assets.Export.Dependencies;
using AssetRipper.Assets.Interfaces;
using AssetRipper.Assets.Metadata;
using AssetRipper.SourceGenerated.Classes.ClassID_114;
using AssetRipper.SourceGenerated.Classes.ClassID_115;
using AssetRipper.SourceGenerated.Classes.ClassID_21;
using AssetRipper.SourceGenerated.Subclasses.Utf8String;

namespace AssetRipper.Processing
{
	public class SpineProcessor : IAssetProcessor
	{
		public void Process(GameBundle gameBundle, UnityVersion projectVersion)
		{
			List<string> assetNames = new();
			
			foreach (IUnityObjectBase asset in gameBundle.FetchAssets())
			{
				if (asset.OriginalDirectory == null)
				{
					string assetName = GetAssetName(asset);
					assetNames.Add(assetName);
				}
			}

			foreach (IUnityObjectBase asset in gameBundle.FetchAssets())
			{
				if (asset is not IMonoBehaviour monoBehaviour)
				{
					continue;
				}

				IMonoScript? script = monoBehaviour.Script_C114P;

				if (script?.Name_C115 != "SkeletonDataAsset" || script?.Namespace_C115 != "Spine.Unity")
				{
					continue;
				}

				DependencyContext dependencyContext = new(true);

				string assetName = GetAssetName(asset);
				if (assetNames.Count(n => n == assetName) > 1)
				{
					asset.OriginalDirectory ??= $"SpineRes/{assetName}_g_{asset.GUID}";
				}
				else
				{
					asset.OriginalDirectory = "SpineRes";
				}

				foreach (PPtr<IUnityObjectBase> ptr in FetchDependencies(asset, dependencyContext))
				{
					if (!ptr.IsNull)
					{
						IUnityObjectBase? dependencyAsset = asset.Collection.TryGetAsset(ptr);

						if (dependencyAsset != null)
						{
							if (dependencyAsset.ClassName is "MonoBehaviour"
							    or "TextAsset"
							    or "Material"
							    or "Texture2D"
							   )
							{
								dependencyAsset.OriginalDirectory = asset.OriginalDirectory;
							}
						}
					}
				}
			}
		}

		public IEnumerable<PPtr<IUnityObjectBase>> FetchDependencies(IUnityObjectBase asset, DependencyContext context)
		{
			IEnumerable<PPtr<IUnityObjectBase>> dependencies;

			if (asset is IMonoBehaviour monoBehaviour && monoBehaviour.Structure != null)
			{
				Utf8String? ns = monoBehaviour.Script_C114P?.Namespace_C115;
				Utf8String? n = monoBehaviour.Script_C114P?.Name_C115;
				if (
					ns == "Spine.Unity"
				)
				{
					dependencies = monoBehaviour.Structure.FetchDependencies(context);
				}
				else
				{
					yield break;
				}
			}
			else
			{
				if (asset is IMaterial)
				{
					dependencies = asset.FetchDependencies((FieldName?)null).Select(
						tuple => tuple.Item2);
				}
				else
				{
					yield break;
				}
			}

			foreach (PPtr<IUnityObjectBase> ptr in dependencies)
			{
				if (!ptr.IsNull)
				{
					yield return ptr;

					IUnityObjectBase? dependencyAsset = asset.Collection.TryGetAsset(ptr);
					if (dependencyAsset != null)
					{
						foreach (PPtr<IUnityObjectBase> dependency in FetchDependencies(dependencyAsset, context))
						{
							yield return dependency;
						}
					}
				}
			}
		}

		public string GetAssetName(IUnityObjectBase asset)
		{
			string? deserializedName = (asset as IHasNameString)?.NameString;
			if (!string.IsNullOrEmpty(deserializedName))
			{
				return deserializedName;
			}

			if (!string.IsNullOrEmpty(asset.OriginalName))
			{
				return asset.OriginalName;
			}

			return asset.ClassName;
		}
	}
}
