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
        collection.AddTransient<MandelbrotSetSettingsPageViewModel>();
        collection.AddTransient<JuliaSetSettingsPageViewModel>();

        collection.AddSingleton<Func<Type, PageViewModel>>(x => type => type switch
        {
            _ when type == typeof(MandelbrotSetSettingsPageViewModel) => x.GetRequiredService<MandelbrotSetSettingsPageViewModel>(),
            _ when type == typeof(JuliaSetSettingsPageViewModel) => x.GetRequiredService<JuliaSetSettingsPageViewModel>(),
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
