using FractalImagesGenerator.WPF.Data;

namespace FractalImagesGenerator.WPF.ViewModels;

public class StartPageViewModel : PageViewModel
{
    private readonly string _description = "Information...";

    public string Description => _description;

    public StartPageViewModel() : base(ApplicationPageName.Start) { }
}
