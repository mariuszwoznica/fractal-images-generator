namespace FractalImagesGenerator.WPF.Models;

public record MandelbrotSetConfiguration(
    int Width,
    int Height,
    int Zoom,
    int MaxIterations,
    double OffsetX,
    double OffsetY);
