using System.Windows.Media.Imaging;

namespace FractalImagesGenerator.WPF.ViewModels;

public class FractalImagePageViewModel() : PageViewModel()
{
    private WriteableBitmap _fractalImage;

    public WriteableBitmap FractalImage
    {
        get => _fractalImage;
        set => SetProperty(ref _fractalImage, value);
    }

}
