using System;
using System.IO;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;

namespace JankiiBuffer;

// https://docs.sixlabors.com/articles/imagesharp/pixelbuffers.html?q=Process%20pixel#use-processpixelrows-for-fast-known-format-access


class ImageProcessor
{

	public static ImageInfo GetImageInfo(string imagePath)
	{
		// Wet code :P

		var img = Image.Load<Rgba32>(imagePath);

		byte[] ba = new byte[img.Width * img.Height * 4];

		img.CopyPixelDataTo(ba);

		return new(img.Width, img.Height, ba);

	}

	public static byte[] GetPixelBuffer(string imagePath)
	{
		var img = Image.Load<Rgba32>(imagePath);

		byte[] ba = new byte[img.Width * img.Height * 4];

		img.CopyPixelDataTo(ba);

		return ba;
	}
}