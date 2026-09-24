using System;

namespace JankiiBuffer;

public interface IConsoleBuffer
{
	public void SetCell(int x, int y, float brightness);
}