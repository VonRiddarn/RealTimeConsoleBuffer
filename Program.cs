using System;
using JankiiBuffer;

namespace RealTimeConsoleBuffer;

class Program
{
	static void Main()
	{
		Console.CursorVisible = false;
		Console.Clear();

		ConsoleBuffer buffer = new();
		buffer.Clear();

		float brightness = 0;

		for (int y = 0; y < buffer.Height; y++)
			for (int x = 0; x < buffer.Width; x++)
			{
				buffer.SetCell(x, y, brightness++);
				if (brightness >= 100)
					brightness = 0;
			}

		buffer.Draw();
	}
}
