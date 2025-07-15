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
            Zoom: Zoom(),
            MaxIterations: ImageConstants.numberOfIterations,
            OffsetX: ToOffsetX(mousePosition.X),
            OffsetY: ToOffsetY(mousePosition.Y) //TODO: fix precision, fix docum.
            );

    private double ToOffsetX(double x)
        => -(((x - 0) / (ImageConstants.width - 0)) * (2 - (-2)) + (-2));

    private double ToOffsetY(double y)
        => -1 - (((y - 0) / (ImageConstants.height - 0)) * (2 - (-2)) + (-2));

    private int Zoom()
        => new Random().Next(10, 5000);

}
