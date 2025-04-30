using FractalImagesGenerator.UI.Base;

namespace FractalImagesGenerator.UI.ViewModels;

public class StartPageViewModel : PageViewModel
{
    private readonly string _description = "Information...";

    public string Description => _description;

    public StartPageViewModel() { }
}
