﻿using AssetRipper.Export.UnityProjects.Configuration;
using AssetRipper.Export.UnityProjects.Utils;
using Avalonia.Media.Imaging;
using System.IO;

namespace AssetRipper.GUI.AssetInformation
{
	public static class AvaloniaBitmapFromDirectBitmap
	{
		/// <summary>
		/// Converts a DirectBitmap into an Avalonia Bitmap. Disposes the DirectBitmap.
		/// </summary>
		public static Bitmap? Make(DirectBitmap directBitmap)
		{
			MemoryStream resultStream = new();
			if (directBitmap.Save(resultStream, ImageExportFormat.Png))
			{
				directBitmap.Dispose();
				resultStream.Seek(0, SeekOrigin.Begin);
				return new Bitmap(resultStream);
			}
			else
			{
				directBitmap.Dispose();
				resultStream.Dispose();
				return null;
			}
		}
	}
}
