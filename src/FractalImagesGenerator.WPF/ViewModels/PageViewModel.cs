using FractalImagesGenerator.WPF.Data;
using FractalImagesGenerator.WPF.Infrastructure;

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

    protected PageViewModel() { }
}
