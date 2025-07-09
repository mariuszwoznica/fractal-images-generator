using FractalImagesGenerator.UI.Data;

namespace FractalImagesGenerator.UI.ViewModels;

public class DisplayPageViewModel() : PageViewModel(ApplicationPageName.None)
{
    private readonly string _description = "Image.";

    public string Description => _description;
}
