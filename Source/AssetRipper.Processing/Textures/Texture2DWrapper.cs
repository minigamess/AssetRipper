using AssetRipper.Assets;
using AssetRipper.Assets.Cloning;
using AssetRipper.Assets.Collections;
using AssetRipper.Assets.Export;
using AssetRipper.Assets.Export.Dependencies;
using AssetRipper.Assets.IO.Reading;
using AssetRipper.Assets.IO.Writing;
using AssetRipper.Assets.Metadata;
using AssetRipper.IO.Endian;
using AssetRipper.IO.Files;
using AssetRipper.SourceGenerated.Classes.ClassID_0;
using AssetRipper.SourceGenerated.Classes.ClassID_1001;
using AssetRipper.SourceGenerated.Classes.ClassID_1001480554;
using AssetRipper.SourceGenerated.Classes.ClassID_1002;
using AssetRipper.SourceGenerated.Classes.ClassID_130;
using AssetRipper.SourceGenerated.Classes.ClassID_18;
using AssetRipper.SourceGenerated.Classes.ClassID_213;
using AssetRipper.SourceGenerated.Classes.ClassID_27;
using AssetRipper.SourceGenerated.Classes.ClassID_28;
using AssetRipper.SourceGenerated.Classes.ClassID_687078895;
using AssetRipper.SourceGenerated.Enums;
using AssetRipper.SourceGenerated.MarkerInterfaces;
using AssetRipper.SourceGenerated.Subclasses.GLTextureSettings;
using AssetRipper.SourceGenerated.Subclasses.PPtr_EditorExtension;
using AssetRipper.SourceGenerated.Subclasses.PPtr_EditorExtensionImpl;
using AssetRipper.SourceGenerated.Subclasses.PPtr_Prefab;
using AssetRipper.SourceGenerated.Subclasses.PPtr_PrefabInstance;
using AssetRipper.SourceGenerated.Subclasses.Rectf;
using AssetRipper.SourceGenerated.Subclasses.StreamingInfo;
using AssetRipper.Yaml;
using Hash128 = AssetRipper.SourceGenerated.Subclasses.Hash128.Hash128;
using Utf8String = AssetRipper.SourceGenerated.Subclasses.Utf8String.Utf8String;

namespace AssetRipper.Processing.Textures
{
	public class Texture2DWrapper : ITexture2D
	{
		private readonly ITexture2D _texture2D;
		public Rectf Rect_C213;

		public void ReadEditor(ref EndianSpanReader reader)
		{
			_texture2D.ReadEditor(ref reader);
		}

		public void ReadRelease(ref EndianSpanReader reader)
		{
			_texture2D.ReadRelease(ref reader);
		}

		public void WriteEditor(AssetWriter writer)
		{
			_texture2D.WriteEditor(writer);
		}

		public void WriteRelease(AssetWriter writer)
		{
			_texture2D.WriteRelease(writer);
		}

		public YamlNode ExportYamlEditor(IExportContainer container)
		{
			return _texture2D.ExportYamlEditor(container);
		}

		public YamlNode ExportYamlRelease(IExportContainer container)
		{
			return _texture2D.ExportYamlRelease(container);
		}

		public IEnumerable<PPtr<IUnityObjectBase>> FetchDependencies(DependencyContext context)
		{
			return _texture2D.FetchDependencies(context);
		}

		public IEnumerable<(FieldName, PPtr<IUnityObjectBase>)> FetchDependencies(FieldName? parent)
		{
			return _texture2D.FetchDependencies(parent);
		}

		public void CopyValues(IUnityAssetBase? source, PPtrConverter converter)
		{
			_texture2D.CopyValues(source, converter);
		}

		public void Reset()
		{
			_texture2D.Reset();
		}

		public AssetInfo AssetInfo => _texture2D.AssetInfo;

		public int ClassID => _texture2D.ClassID;

		public string ClassName => _texture2D.ClassName;

		public AssetCollection Collection => _texture2D.Collection;

		public long PathID => _texture2D.PathID;

		public UnityGUID GUID => _texture2D.GUID;

		public string? OriginalPath
		{
			get => _texture2D.OriginalPath;
			set => _texture2D.OriginalPath = value;
		}

		public string? OriginalDirectory
		{
			get => _texture2D.OriginalDirectory;
			set => _texture2D.OriginalDirectory = value;
		}

		public string? OriginalName
		{
			get => _texture2D.OriginalName;
			set => _texture2D.OriginalName = value;
		}

		public string? OriginalExtension
		{
			get => _texture2D.OriginalExtension;
			set => _texture2D.OriginalExtension = value;
		}

		public string? AssetBundleName
		{
			get => _texture2D.AssetBundleName;
			set => _texture2D.AssetBundleName = value;
		}

		public IUnityObjectBase? MainAsset
		{
			get => _texture2D.MainAsset;
			set => _texture2D.MainAsset = value;
		}

		public YamlDocument ExportYamlDocument(IExportContainer container)
		{
			return _texture2D.ExportYamlDocument(container);
		}

		public IEnumerable<(FieldName, PPtr<IUnityObjectBase>)> FetchDependencies()
		{
			return _texture2D.FetchDependencies();
		}

		public void ReadEditor(AssetReader reader)
		{
			_texture2D.ReadEditor(reader);
		}

		public void ReadRelease(AssetReader reader)
		{
			_texture2D.ReadRelease(reader);
		}

		public string NameString
		{
			get => _texture2D.NameString;
			set => _texture2D.NameString = value;
		}

		public Utf8String Name => _texture2D.Name;

		public HideFlags ObjectHideFlags
		{
			get => _texture2D.ObjectHideFlags;
			set => _texture2D.ObjectHideFlags = value;
		}

		public void CopyValues(IObject source)
		{
			_texture2D.CopyValues(source);
		}

		public uint HideFlags_C0
		{
			get => _texture2D.HideFlags_C0;
			set => _texture2D.HideFlags_C0 = value;
		}

		public HideFlags HideFlags_C0E
		{
			get => _texture2D.HideFlags_C0E;
			set => _texture2D.HideFlags_C0E = value;
		}

		public bool Has_CorrespondingSourceObject_C18()
		{
			return _texture2D.Has_CorrespondingSourceObject_C18();
		}

		public bool Has_ExtensionPtr_C18()
		{
			return _texture2D.Has_ExtensionPtr_C18();
		}

		public bool Has_PrefabAsset_C18()
		{
			return _texture2D.Has_PrefabAsset_C18();
		}

		public bool Has_PrefabInstance_C18()
		{
			return _texture2D.Has_PrefabInstance_C18();
		}

		public bool Has_PrefabInternal_C18()
		{
			return _texture2D.Has_PrefabInternal_C18();
		}

		public void CopyValues(IEditorExtension source, PPtrConverter converter)
		{
			_texture2D.CopyValues(source, converter);
		}

		public void CopyValues(IEditorExtension source)
		{
			_texture2D.CopyValues(source);
		}

		public IPPtr_EditorExtension? CorrespondingSourceObject_C18 => _texture2D.CorrespondingSourceObject_C18;

		public PPtr_EditorExtensionImpl? ExtensionPtr_C18 => _texture2D.ExtensionPtr_C18;

		public uint HideFlags_C18
		{
			get => _texture2D.HideFlags_C18;
			set => _texture2D.HideFlags_C18 = value;
		}

		public PPtr_Prefab_2018_3_0? PrefabAsset_C18 => _texture2D.PrefabAsset_C18;

		public PPtr_PrefabInstance? PrefabInstance_C18 => _texture2D.PrefabInstance_C18;

		public IPPtr_Prefab? PrefabInternal_C18 => _texture2D.PrefabInternal_C18;

		public HideFlags HideFlags_C18E
		{
			get => _texture2D.HideFlags_C18E;
			set => _texture2D.HideFlags_C18E = value;
		}

		public IEditorExtension? CorrespondingSourceObject_C18P
		{
			get => _texture2D.CorrespondingSourceObject_C18P;
			set => _texture2D.CorrespondingSourceObject_C18P = value;
		}

		public IEditorExtensionImpl? ExtensionPtr_C18P
		{
			get => _texture2D.ExtensionPtr_C18P;
			set => _texture2D.ExtensionPtr_C18P = value;
		}

		public IPrefab? PrefabAsset_C18P
		{
			get => _texture2D.PrefabAsset_C18P;
			set => _texture2D.PrefabAsset_C18P = value;
		}

		public IPrefabInstance? PrefabInstance_C18P
		{
			get => _texture2D.PrefabInstance_C18P;
			set => _texture2D.PrefabInstance_C18P = value;
		}

		public IPrefabMarker? PrefabInternal_C18P
		{
			get => _texture2D.PrefabInternal_C18P;
			set => _texture2D.PrefabInternal_C18P = value;
		}

		public bool Has_CorrespondingSourceObject_C130()
		{
			return _texture2D.Has_CorrespondingSourceObject_C130();
		}

		public bool Has_ExtensionPtr_C130()
		{
			return _texture2D.Has_ExtensionPtr_C130();
		}

		public bool Has_PrefabAsset_C130()
		{
			return _texture2D.Has_PrefabAsset_C130();
		}

		public bool Has_PrefabInstance_C130()
		{
			return _texture2D.Has_PrefabInstance_C130();
		}

		public bool Has_PrefabInternal_C130()
		{
			return _texture2D.Has_PrefabInternal_C130();
		}

		public void CopyValues(INamedObject source, PPtrConverter converter)
		{
			_texture2D.CopyValues(source, converter);
		}

		public void CopyValues(INamedObject source)
		{
			_texture2D.CopyValues(source);
		}

		public IPPtr_EditorExtension? CorrespondingSourceObject_C130 => _texture2D.CorrespondingSourceObject_C130;

		public PPtr_EditorExtensionImpl? ExtensionPtr_C130 => _texture2D.ExtensionPtr_C130;

		public uint HideFlags_C130
		{
			get => _texture2D.HideFlags_C130;
			set => _texture2D.HideFlags_C130 = value;
		}

		public Utf8String Name_C130 => _texture2D.Name_C130;

		public PPtr_Prefab_2018_3_0? PrefabAsset_C130 => _texture2D.PrefabAsset_C130;

		public PPtr_PrefabInstance? PrefabInstance_C130 => _texture2D.PrefabInstance_C130;

		public IPPtr_Prefab? PrefabInternal_C130 => _texture2D.PrefabInternal_C130;

		public HideFlags HideFlags_C130E
		{
			get => _texture2D.HideFlags_C130E;
			set => _texture2D.HideFlags_C130E = value;
		}

		public IEditorExtension? CorrespondingSourceObject_C130P
		{
			get => _texture2D.CorrespondingSourceObject_C130P;
			set => _texture2D.CorrespondingSourceObject_C130P = value;
		}

		public IEditorExtensionImpl? ExtensionPtr_C130P
		{
			get => _texture2D.ExtensionPtr_C130P;
			set => _texture2D.ExtensionPtr_C130P = value;
		}

		public IPrefab? PrefabAsset_C130P
		{
			get => _texture2D.PrefabAsset_C130P;
			set => _texture2D.PrefabAsset_C130P = value;
		}

		public IPrefabInstance? PrefabInstance_C130P
		{
			get => _texture2D.PrefabInstance_C130P;
			set => _texture2D.PrefabInstance_C130P = value;
		}

		public IPrefabMarker? PrefabInternal_C130P
		{
			get => _texture2D.PrefabInternal_C130P;
			set => _texture2D.PrefabInternal_C130P = value;
		}

		public bool Has_CorrespondingSourceObject_C27()
		{
			return _texture2D.Has_CorrespondingSourceObject_C27();
		}

		public bool Has_DownscaleFallback_C27()
		{
			return _texture2D.Has_DownscaleFallback_C27();
		}

		public bool Has_ExtensionPtr_C27()
		{
			return _texture2D.Has_ExtensionPtr_C27();
		}

		public bool Has_ForcedFallbackFormat_C27()
		{
			return _texture2D.Has_ForcedFallbackFormat_C27();
		}

		public bool Has_ImageContentsHash_C27()
		{
			return _texture2D.Has_ImageContentsHash_C27();
		}

		public bool Has_IsAlphaChannelOptional_C27()
		{
			return _texture2D.Has_IsAlphaChannelOptional_C27();
		}

		public bool Has_PrefabAsset_C27()
		{
			return _texture2D.Has_PrefabAsset_C27();
		}

		public bool Has_PrefabInstance_C27()
		{
			return _texture2D.Has_PrefabInstance_C27();
		}

		public bool Has_PrefabInternal_C27()
		{
			return _texture2D.Has_PrefabInternal_C27();
		}

		public void CopyValues(ITexture source, PPtrConverter converter)
		{
			_texture2D.CopyValues(source, converter);
		}

		public void CopyValues(ITexture source)
		{
			_texture2D.CopyValues(source);
		}

		public IPPtr_EditorExtension? CorrespondingSourceObject_C27 => _texture2D.CorrespondingSourceObject_C27;

		public bool DownscaleFallback_C27
		{
			get => _texture2D.DownscaleFallback_C27;
			set => _texture2D.DownscaleFallback_C27 = value;
		}

		public PPtr_EditorExtensionImpl? ExtensionPtr_C27 => _texture2D.ExtensionPtr_C27;

		public int ForcedFallbackFormat_C27
		{
			get => _texture2D.ForcedFallbackFormat_C27;
			set => _texture2D.ForcedFallbackFormat_C27 = value;
		}

		public uint HideFlags_C27
		{
			get => _texture2D.HideFlags_C27;
			set => _texture2D.HideFlags_C27 = value;
		}

		public Hash128? ImageContentsHash_C27 => _texture2D.ImageContentsHash_C27;

		public bool IsAlphaChannelOptional_C27
		{
			get => _texture2D.IsAlphaChannelOptional_C27;
			set => _texture2D.IsAlphaChannelOptional_C27 = value;
		}

		public PPtr_Prefab_2018_3_0? PrefabAsset_C27 => _texture2D.PrefabAsset_C27;

		public PPtr_PrefabInstance? PrefabInstance_C27 => _texture2D.PrefabInstance_C27;

		public IPPtr_Prefab? PrefabInternal_C27 => _texture2D.PrefabInternal_C27;

		public HideFlags HideFlags_C27E
		{
			get => _texture2D.HideFlags_C27E;
			set => _texture2D.HideFlags_C27E = value;
		}

		public IEditorExtension? CorrespondingSourceObject_C27P
		{
			get => _texture2D.CorrespondingSourceObject_C27P;
			set => _texture2D.CorrespondingSourceObject_C27P = value;
		}

		public IEditorExtensionImpl? ExtensionPtr_C27P
		{
			get => _texture2D.ExtensionPtr_C27P;
			set => _texture2D.ExtensionPtr_C27P = value;
		}

		public IPrefab? PrefabAsset_C27P
		{
			get => _texture2D.PrefabAsset_C27P;
			set => _texture2D.PrefabAsset_C27P = value;
		}

		public IPrefabInstance? PrefabInstance_C27P
		{
			get => _texture2D.PrefabInstance_C27P;
			set => _texture2D.PrefabInstance_C27P = value;
		}

		public IPrefabMarker? PrefabInternal_C27P
		{
			get => _texture2D.PrefabInternal_C27P;
			set => _texture2D.PrefabInternal_C27P = value;
		}

		public bool Has_AlphaIsTransparency_C28()
		{
			return _texture2D.Has_AlphaIsTransparency_C28();
		}

		public bool Has_ColorSpace_C28()
		{
			return _texture2D.Has_ColorSpace_C28();
		}

		public bool Has_CompleteImageSize_C28_Int32()
		{
			return _texture2D.Has_CompleteImageSize_C28_Int32();
		}

		public bool Has_CompleteImageSize_C28_UInt32()
		{
			return _texture2D.Has_CompleteImageSize_C28_UInt32();
		}

		public bool Has_CorrespondingSourceObject_C28()
		{
			return _texture2D.Has_CorrespondingSourceObject_C28();
		}

		public bool Has_DownscaleFallback_C28()
		{
			return _texture2D.Has_DownscaleFallback_C28();
		}

		public bool Has_ExtensionPtr_C28()
		{
			return _texture2D.Has_ExtensionPtr_C28();
		}

		public bool Has_ForcedFallbackFormat_C28()
		{
			return _texture2D.Has_ForcedFallbackFormat_C28();
		}

		public bool Has_IgnoreMasterTextureLimit_C28()
		{
			return _texture2D.Has_IgnoreMasterTextureLimit_C28();
		}

		public bool Has_IgnoreMipmapLimit_C28()
		{
			return _texture2D.Has_IgnoreMipmapLimit_C28();
		}

		public bool Has_ImageContentsHash_C28()
		{
			return _texture2D.Has_ImageContentsHash_C28();
		}

		public bool Has_IsAlphaChannelOptional_C28()
		{
			return _texture2D.Has_IsAlphaChannelOptional_C28();
		}

		public bool Has_IsPreProcessed_C28()
		{
			return _texture2D.Has_IsPreProcessed_C28();
		}

		public bool Has_MipCount_C28()
		{
			return _texture2D.Has_MipCount_C28();
		}

		public bool Has_MipMap_C28()
		{
			return _texture2D.Has_MipMap_C28();
		}

		public bool Has_MipmapLimitGroupName_C28()
		{
			return _texture2D.Has_MipmapLimitGroupName_C28();
		}

		public bool Has_MipsStripped_C28()
		{
			return _texture2D.Has_MipsStripped_C28();
		}

		public bool Has_PlatformBlob_C28()
		{
			return _texture2D.Has_PlatformBlob_C28();
		}

		public bool Has_PrefabAsset_C28()
		{
			return _texture2D.Has_PrefabAsset_C28();
		}

		public bool Has_PrefabInstance_C28()
		{
			return _texture2D.Has_PrefabInstance_C28();
		}

		public bool Has_PrefabInternal_C28()
		{
			return _texture2D.Has_PrefabInternal_C28();
		}

		public bool Has_ReadAllowed_C28()
		{
			return _texture2D.Has_ReadAllowed_C28();
		}

		public bool Has_StreamData_C28()
		{
			return _texture2D.Has_StreamData_C28();
		}

		public bool Has_StreamingMipmaps_C28()
		{
			return _texture2D.Has_StreamingMipmaps_C28();
		}

		public bool Has_StreamingMipmapsPriority_C28()
		{
			return _texture2D.Has_StreamingMipmapsPriority_C28();
		}

		public bool Has_VTOnly_C28()
		{
			return _texture2D.Has_VTOnly_C28();
		}

		public void CopyValues(ITexture2D source, PPtrConverter converter)
		{
			_texture2D.CopyValues(source, converter);
		}

		public void CopyValues(ITexture2D source)
		{
			_texture2D.CopyValues(source);
		}

		public bool AlphaIsTransparency_C28
		{
			get => _texture2D.AlphaIsTransparency_C28;
			set => _texture2D.AlphaIsTransparency_C28 = value;
		}

		public int ColorSpace_C28
		{
			get => _texture2D.ColorSpace_C28;
			set => _texture2D.ColorSpace_C28 = value;
		}

		public int CompleteImageSize_C28_Int32
		{
			get => _texture2D.CompleteImageSize_C28_Int32;
			set => _texture2D.CompleteImageSize_C28_Int32 = value;
		}

		public uint CompleteImageSize_C28_UInt32
		{
			get => _texture2D.CompleteImageSize_C28_UInt32;
			set => _texture2D.CompleteImageSize_C28_UInt32 = value;
		}

		public IPPtr_EditorExtension? CorrespondingSourceObject_C28 => _texture2D.CorrespondingSourceObject_C28;

		public int Dimension_C28
		{
			get => _texture2D.Dimension_C28;
			set => _texture2D.Dimension_C28 = value;
		}

		public bool DownscaleFallback_C28
		{
			get => _texture2D.DownscaleFallback_C28;
			set => _texture2D.DownscaleFallback_C28 = value;
		}

		public PPtr_EditorExtensionImpl? ExtensionPtr_C28 => _texture2D.ExtensionPtr_C28;

		public int ForcedFallbackFormat_C28
		{
			get => _texture2D.ForcedFallbackFormat_C28;
			set => _texture2D.ForcedFallbackFormat_C28 = value;
		}

		public int Format_C28
		{
			get => _texture2D.Format_C28;
			set => _texture2D.Format_C28 = value;
		}

		public int Height_C28
		{
			get => _texture2D.Height_C28;
			set => _texture2D.Height_C28 = value;
		}

		public uint HideFlags_C28
		{
			get => _texture2D.HideFlags_C28;
			set => _texture2D.HideFlags_C28 = value;
		}

		public bool IgnoreMasterTextureLimit_C28
		{
			get => _texture2D.IgnoreMasterTextureLimit_C28;
			set => _texture2D.IgnoreMasterTextureLimit_C28 = value;
		}

		public bool IgnoreMipmapLimit_C28
		{
			get => _texture2D.IgnoreMipmapLimit_C28;
			set => _texture2D.IgnoreMipmapLimit_C28 = value;
		}

		public Hash128? ImageContentsHash_C28 => _texture2D.ImageContentsHash_C28;

		public int ImageCount_C28
		{
			get => _texture2D.ImageCount_C28;
			set => _texture2D.ImageCount_C28 = value;
		}

		public byte[] ImageData_C28
		{
			get => _texture2D.ImageData_C28;
			set => _texture2D.ImageData_C28 = value;
		}

		public bool IsAlphaChannelOptional_C28
		{
			get => _texture2D.IsAlphaChannelOptional_C28;
			set => _texture2D.IsAlphaChannelOptional_C28 = value;
		}

		public bool IsPreProcessed_C28
		{
			get => _texture2D.IsPreProcessed_C28;
			set => _texture2D.IsPreProcessed_C28 = value;
		}

		public bool IsReadable_C28
		{
			get => _texture2D.IsReadable_C28;
			set => _texture2D.IsReadable_C28 = value;
		}

		public int LightmapFormat_C28
		{
			get => _texture2D.LightmapFormat_C28;
			set => _texture2D.LightmapFormat_C28 = value;
		}

		public int MipCount_C28
		{
			get => _texture2D.MipCount_C28;
			set => _texture2D.MipCount_C28 = value;
		}

		public bool MipMap_C28
		{
			get => _texture2D.MipMap_C28;
			set => _texture2D.MipMap_C28 = value;
		}

		public Utf8String? MipmapLimitGroupName_C28 => _texture2D.MipmapLimitGroupName_C28;

		public int MipsStripped_C28
		{
			get => _texture2D.MipsStripped_C28;
			set => _texture2D.MipsStripped_C28 = value;
		}

		public Utf8String Name_C28 => _texture2D.Name_C28;

		public byte[]? PlatformBlob_C28
		{
			get => _texture2D.PlatformBlob_C28;
			set => _texture2D.PlatformBlob_C28 = value;
		}

		public PPtr_Prefab_2018_3_0? PrefabAsset_C28 => _texture2D.PrefabAsset_C28;

		public PPtr_PrefabInstance? PrefabInstance_C28 => _texture2D.PrefabInstance_C28;

		public IPPtr_Prefab? PrefabInternal_C28 => _texture2D.PrefabInternal_C28;

		public bool ReadAllowed_C28
		{
			get => _texture2D.ReadAllowed_C28;
			set => _texture2D.ReadAllowed_C28 = value;
		}

		public IStreamingInfo? StreamData_C28 => _texture2D.StreamData_C28;

		public bool StreamingMipmaps_C28
		{
			get => _texture2D.StreamingMipmaps_C28;
			set => _texture2D.StreamingMipmaps_C28 = value;
		}

		public int StreamingMipmapsPriority_C28
		{
			get => _texture2D.StreamingMipmapsPriority_C28;
			set => _texture2D.StreamingMipmapsPriority_C28 = value;
		}

		public IGLTextureSettings TextureSettings_C28 => _texture2D.TextureSettings_C28;

		public bool VTOnly_C28
		{
			get => _texture2D.VTOnly_C28;
			set => _texture2D.VTOnly_C28 = value;
		}

		public int Width_C28
		{
			get => _texture2D.Width_C28;
			set => _texture2D.Width_C28 = value;
		}

		public TextureDimension Dimension_C28E
		{
			get => _texture2D.Dimension_C28E;
			set => _texture2D.Dimension_C28E = value;
		}

		public TextureFormat Format_C28E
		{
			get => _texture2D.Format_C28E;
			set => _texture2D.Format_C28E = value;
		}

		public HideFlags HideFlags_C28E
		{
			get => _texture2D.HideFlags_C28E;
			set => _texture2D.HideFlags_C28E = value;
		}

		public IEditorExtension? CorrespondingSourceObject_C28P
		{
			get => _texture2D.CorrespondingSourceObject_C28P;
			set => _texture2D.CorrespondingSourceObject_C28P = value;
		}

		public IEditorExtensionImpl? ExtensionPtr_C28P
		{
			get => _texture2D.ExtensionPtr_C28P;
			set => _texture2D.ExtensionPtr_C28P = value;
		}

		public IPrefab? PrefabAsset_C28P
		{
			get => _texture2D.PrefabAsset_C28P;
			set => _texture2D.PrefabAsset_C28P = value;
		}

		public IPrefabInstance? PrefabInstance_C28P
		{
			get => _texture2D.PrefabInstance_C28P;
			set => _texture2D.PrefabInstance_C28P = value;
		}

		public IPrefabMarker? PrefabInternal_C28P
		{
			get => _texture2D.PrefabInternal_C28P;
			set => _texture2D.PrefabInternal_C28P = value;
		}

		public Dictionary<ISprite, ISpriteAtlas?>? SpriteInformation
		{
			get => _texture2D.SpriteInformation;
			set => _texture2D.SpriteInformation = value;
		}

		public Texture2DWrapper(ITexture2D texture2D)
		{
			_texture2D = texture2D;
		}
	}
}
