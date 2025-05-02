using FractalImagesGenerator.UI.Base;
using FractalImagesGenerator.UI.ViewModels;
using FractalImagesGenerator.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace FractalImagesGenerator.UI;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var collection = new ServiceCollection();
        collection.AddSingleton<MainViewModel>();
        collection.AddSingleton<StartPageViewModel>();
        collection.AddTransient<MandelbrotSetPageViewModel>();
        collection.AddTransient<JuliaSetPageViewModel>();
        collection.AddTransient<DisplayPageViewModel>();

        collection.AddSingleton<Func<Type, PageViewModel>>(provider => type => type switch
        {
            _ when type == typeof(StartPageViewModel) => provider.GetRequiredService<StartPageViewModel>(),
            _ when type == typeof(MandelbrotSetPageViewModel) => provider.GetRequiredService<MandelbrotSetPageViewModel>(),
            _ when type == typeof(JuliaSetPageViewModel) => provider.GetRequiredService<JuliaSetPageViewModel>(),
            _ when type == typeof(DisplayPageViewModel) => provider.GetRequiredService<DisplayPageViewModel>(),
            _ => throw new InvalidOperationException()
        });
        collection.AddSingleton<PageFactory>();

        var serviceProvider = collection.BuildServiceProvider();


        MainView view = new()
        {
            DataContext = serviceProvider.GetRequiredService<MainViewModel>()
        };
        view.Show();

        base.OnStartup(e);
    }
}
