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

    public ICommand MSetSettingsCommand => new RelayCommand(()
        => CurrentPage = _pageFactory.GetPageViewModel<MandelbrotSetSettingsPageViewModel>());

    public ICommand JSetSettingsCommand => new RelayCommand(() 
        => CurrentPage = _pageFactory.GetPageViewModel<JuliaSetSettingsPageViewModel>());


    public MainViewModel(PageFactory factory) 
    {
        _pageFactory = factory;
    }

}
