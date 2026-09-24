using System;
using JankiiBuffer;

namespace RealTimeConsoleBuffer;

// https://stackoverflow.com/questions/596216/formula-to-determine-perceived-brightness-of-rgb-color
// Luminance (standard for certain colour spaces): (0.2126*R + 0.7152*G + 0.0722*B)
// Luminance (perceived option 1): (0.299*R + 0.587*G + 0.114*B)
// Luminance (perceived option 2, slower to calculate): sqrt( 0.299*R^2 + 0.587*G^2 + 0.114*B^2 )

class Program
{
	static void Main()
	{
		Console.CursorVisible = false;
		Console.Clear();

		var image = ImageProcessor.GetImageInfo("images/timmy.png");
		ConsoleBuffer buffer = new(image.Width, image.Height);
		buffer.Clear();

		// TODO: Move this somewhere better...
		for (int y = 0; y < buffer.Height; y++)
		{
			for (int x = 0; x < buffer.Width; x++)
			{
				int index = y * buffer.Width + x;

				// Byte offset
				index *= 4;

				byte r = image.PixelBuffer[index];
				byte g = image.PixelBuffer[index + 1];
				byte b = image.PixelBuffer[index + 2];
				//byte a = image.PixelBuffer[index + 3];

				float brightness = (0.2126f * (float)r + 0.7152f * (float)g + 0.0722f * (float)b) / 255f * 100f;

				// Console.WriteLine($"R {r}\tG {g}\tB {b}\t A {a}\tBR {brightness}");

				buffer.SetCell(x, y, brightness);
			}
		}

		buffer.Draw();
	}
}