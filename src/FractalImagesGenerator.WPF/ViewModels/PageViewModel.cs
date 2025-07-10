using FractalImagesGenerator.WPF.Data;
using FractalImagesGenerator.WPF.ViewModels.Base;

namespace FractalImagesGenerator.WPF.ViewModels;

public class PageViewModel : BaseViewModel
{
    private ApplicationPageName _pageName;

    public ApplicationPageName PageName
    {
        get => _pageName;
        set => SetProperty(ref _pageName, value);
    }

    protected PageViewModel(ApplicationPageName pageName)
    {
        _pageName = pageName;
    }
}
