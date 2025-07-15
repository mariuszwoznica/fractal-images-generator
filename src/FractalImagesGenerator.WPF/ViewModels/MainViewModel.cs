using FractalImagesGenerator.WPF.Data;
using FractalImagesGenerator.WPF.Infrastructure;
using System.Windows.Input;

namespace FractalImagesGenerator.WPF.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly PageFactory _pageFactory;
    private PageViewModel _currentPage;

    public PageViewModel CurrentPage
    {
        get => _currentPage;
        set
        {
            SetProperty(ref _currentPage, value);
            OnPropertyChanged(nameof(MandelbrotSetPageIsActive));
        }
    }

    public bool MandelbrotSetPageIsActive => CurrentPage.PageName == ApplicationPageName.MandelbrotSet;

    public MainViewModel(PageFactory factory)
    {
        _pageFactory = factory;
        _currentPage = _pageFactory.GetPageViewModel<StartPageViewModel>();
    }

    public ICommand MandelbrotSetCommand => new RelayCommand(()
        => CurrentPage = _pageFactory.GetPageViewModel<MandelbrotSetPageViewModel>());

    public ICommand JuliaSetCommand => new RelayCommand(() 
        => CurrentPage = _pageFactory.GetPageViewModel<JuliaSetPageViewModel>());

}
