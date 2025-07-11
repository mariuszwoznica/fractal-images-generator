using FractalImagesGenerator.WPF.Data;
using FractalImagesGenerator.WPF.Services;
using FractalImagesGenerator.WPF.Utilities;
using System.Windows;

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
            PlotAsync();
        }
    }

    private async void PlotAsync()
    {
        var bytes = await GetFractalBytesDataAsync();
        ToFractalImagePage(bytes);
    }

    private async Task<byte[]> GetFractalBytesDataAsync()
        => await fractal.PlotMandelbrotSetAsync(configurationService.SetMandelbrotSetConfiguration(MousePosition));

    private void ToFractalImagePage(byte[] bytes)
    {
        mainViewModel.CurrentPage = pageFactory.GetPageViewModel<FractalImagePageViewModel>(action =>
        {
            action.PageName = ApplicationPageName.MandelbrotSet;
            action.FractalImage = bytes.ToWriteableBitmap();
        });
    }
}
