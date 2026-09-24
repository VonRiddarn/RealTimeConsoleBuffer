using System;
using System.IO;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;

namespace JankiiBuffer;

class ImageProcessor
{
	public static byte[] GetPixelBuffer(string imagePath)
	{
		var img = Image.Load<Rgba32>(imagePath);

		byte[] ba = new byte[img.Width * img.Height * 4];

		img.CopyPixelDataTo(ba);

		return ba;
	}
}