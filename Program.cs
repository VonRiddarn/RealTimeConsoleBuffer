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

		ConsoleBuffer buffer = new();
		buffer.Clear();

		float brightness = 0;

		// for (int y = 0; y < buffer.Height; y++)
		// 	for (int x = 0; x < buffer.Width; x++)
		// 	{
		// 		buffer.SetCell(x, y, brightness++);
		// 		if (brightness >= 100)
		// 			brightness = 0;
		// 	}

		buffer.Draw();

		var arr = ImageProcessor.GetPixelBuffer("timmy.png");

		Console.WriteLine(arr.Length);
		Console.WriteLine(arr.Length % 4);
		Console.WriteLine($"{arr[0]},{arr[1]},{arr[2]},{arr[3]}");

	}
}
