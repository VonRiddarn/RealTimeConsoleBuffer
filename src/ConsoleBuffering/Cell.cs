using System;

namespace JankiiBuffer;

public struct Cell
{
	public float Brightness { get; private set; } = 0;
	public char Char { get; private set; } = ' ';

	static readonly char[] _chars = [
	'$', '@', 'B', '%', '8', '&', 'W', 'M', '#', '*',
	'o', 'a', 'h', 'k', 'b', 'd', 'p', 'q', 'w', 'm',
	'Z', 'O', '0', 'Q', 'L', 'C', 'J', 'U', 'Y', 'X',
	'z', 'c', 'v', 'u', 'n', 'x', 'r', 'j', 'f', 't',
	'/', '\\', '|', '(', ')', '1', '{', '}', '[', ']',
	'?', '-', '_', '+', '~', '<', '>', 'i', '!', 'l',
	'I', ';', ':', ',', '"', '^', '`', '\'', '.', ' ' ];

	public Cell(float brightness = 0)
		=> Update(brightness);


	public void Update(float brightness)
	{
		int index = (int)MathF.Round(0.69f * brightness);
		Char = _chars[69 - index];
		Brightness = brightness;
	}

	public readonly bool Equals(Cell b)
		=> Char == b.Char && Brightness == b.Brightness;
}