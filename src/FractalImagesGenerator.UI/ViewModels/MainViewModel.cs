namespace FractalImagesGenerator.UI.ViewModels;

public class MainViewModel : BaseViewModel
{
    public ApplicationPageName CurrentPage { get; set; } = ApplicationPageName.Undefined;
        
    public MainViewModel()
    {
    }
}
