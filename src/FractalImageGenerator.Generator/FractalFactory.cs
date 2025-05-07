using FractalImageGenerator.Generator.Configurations;
using FractalImageGenerator.Generator.Fractals;

namespace FractalImageGenerator.Generator;

public class FractalFactory
{
    /// <summary>
    /// Instantiates a fractal class based on a configuration file.
    /// </summary>
    /// <param name="configuration">Specifies parameters needed to render a fractal</param>
    /// <returns>Instance of a specific fractal class.</returns>
    public IFractal Get(IFractalConfiguration configuration) 
        => configuration switch
        {
            MandelbrotSetConfiguration config => new MandelbrotSet(config),
            _ => throw new NotImplementedException()
        };
}
