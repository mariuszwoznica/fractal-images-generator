using FractalImageGenerator.Generator.Extensions;
using FractalImagesGenerator.WPF.Services;
using FractalImagesGenerator.WPF.ViewModels;
using FractalImagesGenerator.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace FractalImagesGenerator.WPF;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var collection = new ServiceCollection();
        collection.AddSingleton<MainViewModel>();
        collection.AddSingleton<StartPageViewModel>();
        collection.AddTransient<MandelbrotSetPageViewModel>();
        collection.AddTransient<JuliaSetPageViewModel>();
        collection.AddTransient<FractalImagePageViewModel>();

        collection.AddSingleton<Func<Type, PageViewModel>>(provider => type => type switch
        {
            _ when type == typeof(StartPageViewModel) => provider.GetRequiredService<StartPageViewModel>(),
            _ when type == typeof(MandelbrotSetPageViewModel) => provider.GetRequiredService<MandelbrotSetPageViewModel>(),
            _ when type == typeof(JuliaSetPageViewModel) => provider.GetRequiredService<JuliaSetPageViewModel>(),
            _ when type == typeof(FractalImagePageViewModel) => provider.GetRequiredService<FractalImagePageViewModel>(),
            _ => throw new InvalidOperationException()
        });
        collection.AddSingleton<PageFactory>();
        collection.AddSingleton<Fractal>();
        collection.AddTransient<FractalConfigurationService>();

        collection.AddGenerator();

        var serviceProvider = collection.BuildServiceProvider();


        MainView view = new()
        {
            DataContext = serviceProvider.GetRequiredService<MainViewModel>()
        };
        view.Show();

        base.OnStartup(e);
    }
}
