using FractalImagesGenerator.WPF.Data;
using FractalImagesGenerator.WPF.Infrastructure;
using FractalImagesGenerator.WPF.Services;
using FractalImagesGenerator.WPF.Utilities;
using System.Windows;
using System.Windows.Input;

namespace FractalImagesGenerator.WPF.ViewModels;

public class MandelbrotSetPageViewModel(
    MainViewModel mainViewModel,
    PageFactory pageFactory,
    FractalConfigurationService configurationService,
    Fractal fractal) : PageViewModel(ApplicationPageName.MandelbrotSet)
{
    private readonly string _description = "Click on the image in the area for which " +
        "you want to generate images. To obtain the best-looking images, " +
        "choose a place near white parts in the fractal border area.";
    private Point _mousePosition;

    public string Description => _description;
    public Point MousePosition
    {
        get => _mousePosition;
        set
        {
            SetProperty(ref _mousePosition, value);
            PlotAsyncCommand.Execute(value);
        }
    }

    public ICommand PlotAsyncCommand => new AsyncRelayCommand<Point>((mousePosition)
        => PlotAsync(mousePosition));

    private async Task PlotAsync(Point mousePosition)
    {
        var bytes = await GetImageBytesAsync(mousePosition);
        ToFractalImagePage(bytes);
    }

    private async Task<byte[]> GetImageBytesAsync(Point mousePosition)
        => await fractal.PlotMandelbrotSetAsync(configurationService.SetMandelbrotSetConfiguration(mousePosition));

    private void ToFractalImagePage(byte[] bytes)
    {
        mainViewModel.CurrentPage = pageFactory.GetPageViewModel<FractalImagePageViewModel>(action =>
        {
            action.PageName = ApplicationPageName.MandelbrotSet;
            action.FractalImage = bytes.ToWriteableBitmap();
        });
    }
}
