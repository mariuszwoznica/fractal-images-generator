using FractalImageGenerator.Generator;
using FractalImagesGenerator.UI.Models;

namespace FractalImagesGenerator.UI;

public class Fractal(Generator generator)
{
    public async Task<byte[]> PlottMandelbrotSetAsync(MandelbrotSetConfiguration configuration)
    {
        var fractalConfiguration = generator.CreateMandelbrotSetConfiguration(
            width: configuration.Width,
            height: configuration.Height,
            zoom: configuration.Zoom,
            maxIterations: configuration.MaxIterations,
            offsetX: configuration.OffsetX,
            offsetY: configuration.OffsetY);

        return generator.GenerateFractal(fractalConfiguration);
    }
}
