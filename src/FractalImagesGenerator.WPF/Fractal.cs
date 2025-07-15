using FractalImageGenerator.Generator;
using FractalImagesGenerator.WPF.Models;

namespace FractalImagesGenerator.WPF;

public class Fractal(Generator generator)
{
    public async Task<byte[]> PlotMandelbrotSetAsync(MandelbrotSetConfiguration configuration)
    {
        var fractalConfiguration = generator.CreateMandelbrotSetConfiguration(
            width: configuration.Width,
            height: configuration.Height,
            zoom: configuration.Zoom,
            maxIterations: configuration.MaxIterations,
            offsetX: configuration.OffsetX,
            offsetY: configuration.OffsetY);

        return await Task.Run(() => generator.GenerateFractal(fractalConfiguration));
    }
}
