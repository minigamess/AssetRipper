﻿using AssetRipper.Assets.Generics;
using AssetRipper.Numerics;
using AssetRipper.SourceGenerated.Classes.ClassID_213;
using AssetRipper.SourceGenerated.Classes.ClassID_687078895;
using AssetRipper.SourceGenerated.Enums;
using AssetRipper.SourceGenerated.Subclasses.SpriteAtlasData;
using AssetRipper.SourceGenerated.Subclasses.SpriteBone;
using AssetRipper.SourceGenerated.Subclasses.SpriteMetaData;
using AssetRipper.SourceGenerated.Subclasses.SpriteRenderData;
using AssetRipper.SourceGenerated.Subclasses.SpriteVertex;
using AssetRipper.SourceGenerated.Subclasses.SubMesh;
using AssetRipper.SourceGenerated.Subclasses.Vector2f;
using System.Buffers.Binary;
using System.Drawing;
using System.Numerics;

namespace AssetRipper.SourceGenerated.Extensions
{
	public static class SpriteMetaDataExtensions
	{
		public static SpriteAlignment GetAlignment(this ISpriteMetaData data)
		{
			return (SpriteAlignment)data.Alignment;
		}

		public static void FillSpriteMetaData(this ISpriteMetaData instance, ISprite sprite, ISpriteAtlas? atlas)
		{
			sprite.GetSpriteCoordinatesInAtlas(atlas, out RectangleF rect, out Vector2 pivot, out Vector4 border);
			instance.NameString = sprite.NameString;
			instance.Rect.CopyValues(rect);
			instance.Alignment = (int)SpriteAlignment.Custom;
			instance.Pivot.CopyValues(pivot);
			instance.Border?.CopyValues(border);
			// if (instance.Has_Outline())
			// {
			// 	GenerateOutline(sprite, atlas, rect, pivot, instance.Outline);
			// }
			// if (instance.Has_PhysicsShape() && sprite.Has_PhysicsShape_C213())
			// {
			// 	GeneratePhysicsShape(sprite, atlas, rect, pivot, instance.PhysicsShape);
			// }
			// instance.TessellationDetail = 0;
			// if (instance.Has_Bones() && sprite.Has_Bones_C213() && instance.Has_SpriteID())
			// {
			// 	// Scale bones based off of the sprite's PPU
			// 	foreach (ISpriteBone bone in sprite.Bones_C213)
			// 	{
			// 		bone.Position.Scale(sprite.PixelsToUnits_C213);
			// 		bone.Length *= sprite.PixelsToUnits_C213;
			//
			// 		// Set root bone position
			// 		if (bone.ParentId == -1)
			// 		{
			// 			bone.Position.X += sprite.Rect_C213.Width / 2;
			// 			bone.Position.Y += sprite.Rect_C213.Height / 2;
			// 		}
			// 	}
			//
			// 	instance.Bones.Clear();
			// 	instance.Bones.Capacity = sprite.Bones_C213.Count;
			// 	foreach (ISpriteBone bone in sprite.Bones_C213)
			// 	{
			// 		instance.Bones.AddNew().CopyValues(bone);
			// 	}
			//
			// 	// NOTE: sprite ID is generated by sprite binary content, but we just generate a random value
			// 	instance.SpriteID.String = Guid.NewGuid().ToString("N");
			//
			// 	instance.SetBoneGeometry(sprite);
			// }
		}

		private static void SetBoneGeometry(this ISpriteMetaData instance, ISprite origin)
		{
			Vector3[]? vertices = null;
			BoneWeight4[]? skin = null;

			origin.RD_C213.VertexData?.ReadData(origin.Collection.Version, origin.Collection.EndianType, null,
				out vertices,
				out Vector3[]? _,//normals,
				out Vector4[]? _,//tangents,
				out ColorFloat[]? _,//colors,
				out skin,
				out Vector2[]? _,//uv0,
				out Vector2[]? _,//uv1,
				out Vector2[]? _,//uv2,
				out Vector2[]? _,//uv3,
				out Vector2[]? _,//uv4,
				out Vector2[]? _,//uv5,
				out Vector2[]? _,//uv6,
				out Vector2[]? _);//uv7);

			if (instance.Has_Vertices())
			{
				instance.Vertices.Clear();

				// Convert Vector3f into Vector2f
				if (vertices is null)
				{
					instance.Vertices.Capacity = 0;
				}
				else
				{
					instance.Vertices.Capacity = vertices.Length;
					for (int i = 0; i < vertices.Length; i++)
					{
						Vector2f_3_5_0 vertex = instance.Vertices.AddNew();

						// Scale and translate vertices properly
						vertex.X = vertices[i].X * origin.PixelsToUnits_C213 + origin.Rect_C213.Width / 2;
						vertex.Y = vertices[i].Y * origin.PixelsToUnits_C213 + origin.Rect_C213.Height / 2;
					}
				}
			}

			if (!origin.RD_C213.Has_IndexBuffer() || origin.RD_C213.IndexBuffer.Length == 0)
			{
				instance.Indices = Array.Empty<int>();
			}
			else
			{
				instance.Indices = new int[origin.RD_C213.IndexBuffer.Length / 2];
				for (int i = 0, j = 0; i < origin.RD_C213.IndexBuffer.Length / 2; i++, j += 2)
				{
					//Endianness might matter here
					instance.Indices[i] = BinaryPrimitives.ReadInt16LittleEndian(origin.RD_C213.IndexBuffer.AsSpan(j, 2));
				}
			}

#warning TODO: SpriteConverter does not generate instance.Edges

			if (instance.Has_Weights())
			{
				instance.Weights.Clear();
				if (skin is not null)
				{
					instance.Weights.EnsureCapacity(skin.Length);
					for (int i = 0; i < skin.Length; i++)
					{
						instance.Weights.Add((Subclasses.BoneWeights4.BoneWeights4_2017_1_0)skin[i]);
					}
				}
			}
		}

		private static void GeneratePhysicsShape(
			ISprite sprite,
			ISpriteAtlas? atlas,
			RectangleF rect,
			Vector2 pivot,
			AssetList<AssetList<Vector2f_3_5_0>> shape)
		{
			if (sprite.Has_PhysicsShape_C213() && sprite.PhysicsShape_C213.Count > 0)
			{
				shape.Clear();
				shape.Capacity = sprite.PhysicsShape_C213.Count;
				float pivotShiftX = rect.Width * pivot.X - rect.Width * 0.5f;
				float pivotShiftY = rect.Height * pivot.Y - rect.Height * 0.5f;
				Vector2 pivotShift = new Vector2(pivotShiftX, pivotShiftY);
				for (int i = 0; i < sprite.PhysicsShape_C213.Count; i++)
				{
					shape.Add(new AssetList<Vector2f_3_5_0>(sprite.PhysicsShape_C213[i].Count));
					for (int j = 0; j < sprite.PhysicsShape_C213[i].Count; j++)
					{
						Vector2 point = (Vector2)sprite.PhysicsShape_C213[i][j] * sprite.PixelsToUnits_C213;
						shape[i].Add((Vector2f_3_5_0)(point + pivotShift));
					}
				}
				FixRotation(sprite, atlas, shape);
			}
		}

		private static void FixRotation(ISprite sprite, ISpriteAtlas? atlas, AssetList<AssetList<Vector2f_3_5_0>> outlines)
		{
			GetPacking(sprite, atlas, out bool isPacked, out SpritePackingRotation rotation);

			if (isPacked)
			{
				switch (rotation)
				{
					case SpritePackingRotation.FlipHorizontal:
						{
							foreach (AssetList<Vector2f_3_5_0> outline in outlines)
							{
								for (int i = 0; i < outline.Count; i++)
								{
									Vector2f_3_5_0 vertex = outline[i];
									outline[i].SetValues(-vertex.X, vertex.Y);
								}
							}
						}
						break;

					case SpritePackingRotation.FlipVertical:
						{
							foreach (AssetList<Vector2f_3_5_0> outline in outlines)
							{
								for (int i = 0; i < outline.Count; i++)
								{
									Vector2f_3_5_0 vertex = outline[i];
									outline[i].SetValues(vertex.X, -vertex.Y);
								}
							}
						}
						break;

					case SpritePackingRotation.Rotate90:
						{
							foreach (AssetList<Vector2f_3_5_0> outline in outlines)
							{
								for (int i = 0; i < outline.Count; i++)
								{
									Vector2f_3_5_0 vertex = outline[i];
									outline[i].SetValues(vertex.Y, vertex.X);
								}
							}
						}
						break;

					case SpritePackingRotation.Rotate180:
						{
							foreach (AssetList<Vector2f_3_5_0> outline in outlines)
							{
								for (int i = 0; i < outline.Count; i++)
								{
									Vector2f_3_5_0 vertex = outline[i];
									outline[i].SetValues(-vertex.X, -vertex.Y);
								}
							}
						}
						break;
				}
			}
		}

		/// <summary>
		/// Pure
		/// </summary>
		/// <param name="sprite"></param>
		/// <param name="atlas"></param>
		/// <param name="isPacked"></param>
		/// <param name="rotation"></param>
		private static void GetPacking(ISprite sprite, ISpriteAtlas? atlas, out bool isPacked, out SpritePackingRotation rotation)
		{
			if (atlas is not null && sprite.Has_RenderDataKey_C213())
			{
				ISpriteAtlasData atlasData = atlas.RenderDataMap_C687078895[sprite.RenderDataKey_C213];
				isPacked = atlasData.IsPacked();
				rotation = atlasData.GetPackingRotation();
			}
			else
			{
				isPacked = sprite.RD_C213.IsPacked();
				rotation = sprite.RD_C213.GetPackingRotation();
			}
		}

		private static void GenerateOutline(
			ISprite sprite,
			ISpriteAtlas? atlas,
			RectangleF rect,
			Vector2 pivot,
			AssetList<AssetList<Vector2f_3_5_0>> outlines)
		{
			GenerateOutline(sprite.RD_C213, sprite.Collection.Version, outlines);
			float pivotShiftX = rect.Width * pivot.X - rect.Width * 0.5f;
			float pivotShiftY = rect.Height * pivot.Y - rect.Height * 0.5f;
			Vector2 pivotShift = new Vector2(pivotShiftX, pivotShiftY);
			foreach (AssetList<Vector2f_3_5_0> outline in outlines)
			{
				for (int i = 0; i < outline.Count; i++)
				{
					Vector2 point = (Vector2)outline[i] * sprite.PixelsToUnits_C213;
					outline[i].CopyValues(point + pivotShift);
				}
			}
			FixRotation(sprite, atlas, outlines);
		}

		private static void GenerateOutline(
			ISpriteRenderData spriteRenderData,
			UnityVersion version,
			AssetList<AssetList<Vector2f_3_5_0>> outlines)
		{
			outlines.Clear();
			if (spriteRenderData.Has_VertexData() && spriteRenderData.SubMeshes!.Count != 0)
			{
				for (int i = 0; i < spriteRenderData.SubMeshes.Count; i++)
				{
					Vector3[] vertices = spriteRenderData.VertexData.GenerateVertices(version, spriteRenderData.SubMeshes[i]);
					List<Vector2[]> vectorArrayList = VertexDataToOutline(spriteRenderData.IndexBuffer, vertices, spriteRenderData.SubMeshes[i]);
					outlines.AddRanges(vectorArrayList);
				}
			}
			else if (spriteRenderData.Has_Vertices() && spriteRenderData.Vertices.Count != 0)
			{
				List<Vector2[]> vectorArrayList = VerticesToOutline(spriteRenderData.Vertices, spriteRenderData.Indices);
				outlines.Capacity = vectorArrayList.Count;
				outlines.AddRanges(vectorArrayList);
			}
		}

		private static List<Vector2[]> VerticesToOutline(AccessListBase<ISpriteVertex> spriteVertexList, ushort[] spriteIndexArray)
		{
			Vector3[] vertices = new Vector3[spriteVertexList.Count];
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = spriteVertexList[i].Pos;
			}

			Vector3i[] triangles = new Vector3i[spriteIndexArray.Length / 3];
			for (int i = 0, j = 0; i < triangles.Length; i++)
			{
				int x = spriteIndexArray[j++];
				int y = spriteIndexArray[j++];
				int z = spriteIndexArray[j++];
				triangles[i] = new Vector3i(x, y, z);
			}

			MeshOutlineGenerator outlineGenerator = new MeshOutlineGenerator(vertices, triangles);
			return outlineGenerator.GenerateOutlines();
		}

		private static List<Vector2[]> VertexDataToOutline(byte[] indexBuffer, Vector3[] vertices, ISubMesh submesh)
		{
			Vector3i[] triangles = new Vector3i[submesh.IndexCount / 3];
			for (int o = (int)submesh.FirstByte, ti = 0; ti < triangles.Length; o += 6, ti++)
			{
				int x = BitConverter.ToUInt16(indexBuffer, o + 0);
				int y = BitConverter.ToUInt16(indexBuffer, o + 2);
				int z = BitConverter.ToUInt16(indexBuffer, o + 4);
				triangles[ti] = new Vector3i(x, y, z);
			}
			MeshOutlineGenerator outlineGenerator = new MeshOutlineGenerator(vertices, triangles);
			return outlineGenerator.GenerateOutlines();
		}

		private static void AddRanges(this AssetList<AssetList<Vector2f_3_5_0>> instance, List<Vector2[]> vectorArrayList)
		{
			foreach (Vector2[] vectorArray in vectorArrayList)
			{
				AssetList<Vector2f_3_5_0> assetList = new AssetList<Vector2f_3_5_0>(vectorArray.Length);
				instance.Add(assetList);
				foreach (Vector2 v in vectorArray)
				{
					assetList.Add((Vector2f_3_5_0)v);
				}
			}
		}
	}
}
