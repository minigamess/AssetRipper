﻿using AssetRipper.Assets;
using AssetRipper.Assets.Collections;
using AssetRipper.Assets.Export;
using AssetRipper.Assets.Metadata;
using AssetRipper.Export.UnityProjects.Project.Exporters;
using AssetRipper.IO.Files;
using AssetRipper.IO.Files.SerializedFiles;

namespace AssetRipper.Export.UnityProjects.Project.Collections
{
	public sealed class IgnoreExportCollection : IExportCollection
	{
		public IgnoreExportCollection(IAssetExporter assetExporter, IUnityObjectBase asset)
		{
			AssetExporter = assetExporter ?? throw new ArgumentNullException(nameof(assetExporter));
			m_asset = asset ?? throw new ArgumentNullException(nameof(asset));
		}

		public bool Export(IExportContainer container, string projectDirectory)
		{
			return false;
		}

		public bool IsContains(IUnityObjectBase asset)
		{
			return asset == m_asset;
		}

		public long GetExportID(IUnityObjectBase asset)
		{
			if (asset == m_asset)
			{
				return ExportIdHandler.GetMainExportID(m_asset);
			}
			throw new ArgumentException(null, nameof(asset));
		}

		public UnityGUID GetExportGUID(IUnityObjectBase _)
		{
			throw new NotSupportedException();
		}

		public MetaPtr CreateExportPointer(IUnityObjectBase asset, bool isLocal)
		{
			if (isLocal)
			{
				throw new ArgumentException(null, nameof(isLocal));
			}

			long exportId = GetExportID(asset);
			AssetType type = AssetExporter.ToExportType(asset);
			return new MetaPtr(exportId, UnityGUID.MissingReference, type);
		}

		public IAssetExporter AssetExporter { get; }
		public AssetCollection File => m_asset.Collection;
		public TransferInstructionFlags Flags => File.Flags;
		public IEnumerable<IUnityObjectBase> Assets => Enumerable.Empty<IUnityObjectBase>();
		public string Name => m_asset.GetType().Name;

		private readonly IUnityObjectBase m_asset;
	}

	public sealed class SkipExportCollection : IExportCollection
	{
		public SkipExportCollection(IAssetExporter assetExporter, IUnityObjectBase asset)
		{
			AssetExporter = assetExporter ?? throw new ArgumentNullException(nameof(assetExporter));
			m_asset = asset ?? throw new ArgumentNullException(nameof(asset));
		}

		public bool Export(IExportContainer container, string projectDirectory)
		{
			return false;
		}

		public bool IsContains(IUnityObjectBase asset)
		{
			return asset == m_asset;
		}

		public long GetExportID(IUnityObjectBase asset)
		{
			if (asset == m_asset)
			{
				return ExportIdHandler.GetMainExportID(m_asset);
			}
			throw new ArgumentException(null, nameof(asset));
		}

		public UnityGUID GetExportGUID(IUnityObjectBase _)
		{
			throw new NotSupportedException();
		}

		public MetaPtr CreateExportPointer(IUnityObjectBase asset, bool isLocal)
		{
			if (isLocal)
			{
				throw new ArgumentException(null, nameof(isLocal));
			}

			long exportId = GetExportID(asset);
			AssetType type = AssetExporter.ToExportType(asset);
			return new MetaPtr(exportId, UnityGUID.MissingReference, type);
		}

		public IAssetExporter AssetExporter { get; }
		public AssetCollection File => m_asset.Collection;
		public TransferInstructionFlags Flags => File.Flags;
		public IEnumerable<IUnityObjectBase> Assets => Enumerable.Empty<IUnityObjectBase>();
		public string Name => m_asset.GetType().Name;

		private readonly IUnityObjectBase m_asset;
	}
}
