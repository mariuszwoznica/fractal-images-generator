using FractalImagesGenerator.WPF.Data;

namespace FractalImagesGenerator.WPF.ViewModels;

public class FractalImagePageViewModel(ApplicationPageName pageName) : 
    PageViewModel(pageName)
{
    private ApplicationPageName _pageName;
}
