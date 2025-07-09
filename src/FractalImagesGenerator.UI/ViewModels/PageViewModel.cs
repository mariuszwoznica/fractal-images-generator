using FractalImagesGenerator.UI.Base;
using FractalImagesGenerator.UI.Data;

namespace FractalImagesGenerator.UI.ViewModels;

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
