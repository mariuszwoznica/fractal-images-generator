using FractalImagesGenerator.WPF.Data;
using FractalImagesGenerator.WPF.Services;
using FractalImagesGenerator.WPF.ViewModels.Base;
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
        set => SetProperty(ref _mousePosition, value);
    }
    
    public ICommand PlotMandelbrotSetCommand => new RelayCommand(() => PlotAsync());

    private async Task PlotAsync()
    {
        var fractalImage = await fractal.PlotMandelbrotSetAsync(
            configurationService.SetMandelbrotSetConfiguration());

        mainViewModel.CurrentPage = pageFactory.GetPageViewModel<FractalImagePageViewModel>();
    }

}
