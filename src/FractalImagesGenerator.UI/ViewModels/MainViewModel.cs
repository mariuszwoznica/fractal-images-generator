using FractalImagesGenerator.UI.Base;
using System.Windows.Input;

namespace FractalImagesGenerator.UI.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly PageFactory _pageFactory;

    private PageViewModel _currentPage;

    public PageViewModel CurrentPage
    {
        get => _currentPage;
        set {
            _currentPage = value;
            OnPropertyChanged();
        }
    }

    public ICommand MandelbrotSetCommand => new RelayCommand(()
        => CurrentPage = _pageFactory.GetPageViewModel<MandelbrotSetPageViewModel>());

    public ICommand JuliaSetCommand => new RelayCommand(() 
        => CurrentPage = _pageFactory.GetPageViewModel<JuliaSetPageViewModel>());


    public MainViewModel(PageFactory factory)
    {
        _pageFactory = factory;
        _currentPage = _pageFactory.GetPageViewModel<StartPageViewModel>();
    }

}
