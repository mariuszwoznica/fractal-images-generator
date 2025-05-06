namespace FractalImageGenerator.Generator;

/// <summary>
/// Contains a paramiters needed to render a Mandelbrot Set.
/// </summary>
public record MandelbrotSetConfiguration(
    int Width, 
    int Height,
    int Zoom,
    int MaxIterations,
    double OffsetX,
    double OffsetY);
