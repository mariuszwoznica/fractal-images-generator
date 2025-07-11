using FractalImagesGenerator.WPF.Models;
using FractalImagesGenerator.WPF.Utilities;
using System.Windows;

namespace FractalImagesGenerator.WPF.Services;

public class FractalConfigurationService
{
    public MandelbrotSetConfiguration SetMandelbrotSetConfiguration(Point mousePosition)
        => new(
            Width: ImageConstants.width,
            Height: ImageConstants.height,
            Zoom: 400,
            MaxIterations: 500,
            OffsetX: 0.73195,
            OffsetY: 0.24072 //TODO: 
            );
}
