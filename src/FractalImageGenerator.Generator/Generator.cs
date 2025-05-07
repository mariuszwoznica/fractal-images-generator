using FractalImageGenerator.Generator.Configurations;

namespace FractalImageGenerator.Generator;

/// <summary>
/// Provides methods for creating a fractal's configuration and a method for creating a fractal.
/// </summary>
public class Generator(FractalFactory factory)
{
    /// <summary>
    /// Creates an array of bytes that represents an image of a fractal.
    /// </summary>
    /// <param name="configuration">Specifies parameters needed to render a fractal</param>
    /// <returns>An array of bytes, where each pixel is represented 
    /// as 4 bytes (blue, red, green and alpha).</returns>
    public byte[] GenerateFractal(IFractalConfiguration configuration)
        => factory.Get(configuration).Render();

    /// <summary>
    /// Creates a configuration file for the Mandelbrot set.
    /// </summary>
    /// <returns><see cref="MandelbrotSetConfiguration"/></returns>
    public IFractalConfiguration CreateMandelbrotSetConfiguration(int width, int height, 
        int zoom, int maxIterations, double offsetX, double offsetY)
        => new MandelbrotSetConfiguration(
            Width: width,
            Height: height,
            Zoom: zoom,
            MaxIterations: maxIterations,
            OffsetX: offsetX,
            OffsetY: offsetY);
}
