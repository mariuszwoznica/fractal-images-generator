using FractalImagesGenerator.UI.Base;

namespace FractalImagesGenerator.UI;

public class PageFactory(Func<Type, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel<T>(Action<T> action = null)
        where T : PageViewModel
    {
        var viewModel = factory(typeof(T));

        action?.Invoke((T)viewModel);

        return viewModel;
    }
}
