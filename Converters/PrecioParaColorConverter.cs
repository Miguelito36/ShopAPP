using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ShopApp.Converters;

public class PrecioParaColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var precio = (decimal)value;
        if (precio >= 0 && precio <= 100)
        {
            return Colors.LimeGreen;
        }
        return Colors.DarkViolet;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}