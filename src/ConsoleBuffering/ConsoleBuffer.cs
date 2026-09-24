using System;

namespace JankiiBuffer;

public class ConsoleBuffer : IConsoleBuffer
{
	public int Width { get; private set; }
	public int Height { get; private set; }

	readonly Cell[] _frontBuffer, _backBuffer;

	public ConsoleBuffer(int width = 120, int height = 30)
	{
		Width = width;
		Height = height;

		// Note, we're using a 1D array and offsetting by segments using Y as a muyltiplier.
		int bufferLength = width * height;

		_frontBuffer = new Cell[bufferLength];
		_backBuffer = new Cell[bufferLength];

		Initialize();
	}

	void Initialize()
	{
		for (int i = 0; i < _backBuffer.Length; i++)
		{
			_backBuffer[i] = new Cell(0);
		}
	}

	public void Clear()
	{
		for (int i = 0; i < _backBuffer.Length; i++)
		{
			_backBuffer[i].Update(0);
		}
	}

	public void SetCell(int x, int y, float brightness)
	{
		if (x < 0 || x >= Width || y < 0 || y >= Height)
			return;

		int index = y * Width + x;

		_backBuffer[index].Update(brightness);
	}

	public void Draw()
	{
		int index;

		for (int y = 0; y < Height; y++)
		{
			for (int x = 0; x < Width; x++)
			{
				index = y * Width + x;

				if (_backBuffer[index].Equals(_frontBuffer[index]))
					continue;

				Console.SetCursorPosition(x, y);

				Console.Write(_backBuffer[index].Char);

				// Sync front buffer to what is currently drawn
				_frontBuffer[index] = _backBuffer[index];
			}
		}
	}
}