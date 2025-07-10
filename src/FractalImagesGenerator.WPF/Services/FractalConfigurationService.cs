using FractalImagesGenerator.WPF.Models;

namespace FractalImagesGenerator.WPF.Services;

public class FractalConfigurationService
{
    public MandelbrotSetConfiguration SetMandelbrotSetConfiguration()
        => new(
            Width: 800,
            Height: 800,
            Zoom: 1,
            MaxIterations: 500,
            OffsetX: 0.73195,
            OffsetY: 0.24072
            );
}
