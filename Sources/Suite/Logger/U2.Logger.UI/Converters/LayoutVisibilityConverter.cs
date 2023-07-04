using System;
using System.Globalization;
using Avalonia.Data.Converters;
using U2.Logger.Core;

namespace U2.Logger.UI;

public class LayoutVisibilityConverter : IValueConverter
{
    public static LayoutVisibilityConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is LayoutViewModel layout && parameter is string targetLayout)
        {
            return layout.Name == targetLayout;
        }

        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
