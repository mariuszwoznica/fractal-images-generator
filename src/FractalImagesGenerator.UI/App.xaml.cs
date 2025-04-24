using FractalImagesGenerator.UI.ViewModels;
using FractalImagesGenerator.UI.Views;
using System.Windows;

namespace FractalImagesGenerator.UI;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MainView view = new();
        MainViewModel viewModel = new();
        view.DataContext = viewModel;
        view.Show();
    }
}
