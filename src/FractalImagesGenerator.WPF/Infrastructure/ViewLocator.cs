using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace FractalImagesGenerator.WPF.Infrastructure;

public class ViewLocator : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return null;

        var viewName = value.GetType().FullName!.Replace(
            "ViewModel", "View", StringComparison.InvariantCulture);
        var type = Type.GetType(viewName);

        if (type == null)
            return null;

        var control = (Control)Activator.CreateInstance(type)!;
        control.DataContext = value;
        return control;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
