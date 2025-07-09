namespace FractalImageGenerator.Generator.Configurations;

/// <summary>
/// Contains parameters needed to render the Mandelbrot set.
/// </summary>
/// <param name="Width">Width of fractal image</param>
/// <param name="Height">Height of fractal image</param>
/// <param name="Zoom">Indicates how much the image is zoomed in; the default value equals 1</param>
/// <param name="MaxIterations">Indicates how many iterations are performed for each point 
/// in order to calculate the escape point</param>
/// <param name="OffsetX">A value in the range of 0 to 1 that allows to adjust the starting point 
/// to a desirable position on the x-axis</param>
/// <param name="OffsetY">A value in the range of -1 to 1 that allows to adjust the starting point 
/// to a desirable position on the y-axis</param>
public record MandelbrotSetConfiguration(
    int Width,
    int Height,
    int Zoom,
    int MaxIterations,
    double OffsetX,
    double OffsetY) : IFractalConfiguration;
