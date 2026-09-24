# RealTimeConsoleBuffer

Console buffer for rendering images in real time

## How do I make it work?

Point the image path to a real image

```cs
// Program.cs
/* Line 18 */ var image = ImageProcessor.GetImageInfo("images/timmy.png");
```

If you go out of bounds for the buffer that's a known issue. Just zoom out the console.
