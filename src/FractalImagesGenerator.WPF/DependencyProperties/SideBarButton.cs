using System.Windows.Controls;
using System.Windows;

namespace FractalImagesGenerator.WPF.DependencyProperties;

public class SideBarButton : Button
{
    public static readonly DependencyProperty IsActiveProperty =
        DependencyProperty.Register(
            nameof(IsActive),
            typeof(bool),
            typeof(SideBarButton));

    public bool IsActive
    {
        get => (bool)GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }
}