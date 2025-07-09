namespace FractalImageGenerator.Generator.Fractals;

public interface IFractal
{
    /// <summary>
    /// Creates data that represents a fractal image.
    /// </summary>
    /// <returns>Array of bytes.</returns>
    byte[] Render();
}
