using FractalImagesGenerator.UI.Base;
using System.Windows.Input;

namespace FractalImagesGenerator.UI.ViewModels;

public class MainViewModel : BaseViewModel
{
    private BaseViewModel _currentPage;

    public BaseViewModel CurrentPage
    {
        get => _currentPage;
        set {
            _currentPage = value;
            OnPropertyChanged();
        }
    }

    private readonly BaseViewModel _mVM = new MandelbrotSetSettingsViewModel();
    private readonly BaseViewModel _jVM = new JuliaSetSettingsViewModel();

    public ICommand MSetSettingsCommand => new RelayCommand(() => CurrentPage = _mVM);
    public ICommand JSetSettingsCommand => new RelayCommand(() => CurrentPage = _jVM);


    public MainViewModel()
    {

    }

}
