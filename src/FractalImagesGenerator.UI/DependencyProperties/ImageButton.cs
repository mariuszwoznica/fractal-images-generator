using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FractalImagesGenerator.UI.DependencyProperties;

public class ImageButton : Button
{
    public static readonly DependencyProperty MousePositionProperty = DependencyProperty.Register(
            nameof(MousePosition),
            typeof(Point),
            typeof(ImageButton),
            new FrameworkPropertyMetadata(
                new Point(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public Point MousePosition
    {
        get => (Point)GetValue(MousePositionProperty);
        set => SetValue(MousePositionProperty, value);
    }

    protected override void OnClick()
    {
        base.OnClick();
        MousePosition = Mouse.GetPosition(this);
    }
}
