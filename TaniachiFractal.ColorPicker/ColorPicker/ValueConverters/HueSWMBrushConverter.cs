using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TaniachiFractal.ColorPicker.ColorPicker.ValueConverters
{
    /// <summary>
    /// HSL hue to <see cref="SolidColorBrush"/> converter
    /// </summary>
    public class HueSWMBrushConverter : IValueConverter
    {
        /// <summary>
        /// HSL hue to <see cref="SolidColorBrush"/>
        /// </summary>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte hue)
            {
                var (r, g, b) = ColorCodeConverter.HSLToRGB(hue);
                var output = new SolidColorBrush(Color.FromRgb(r, g, b));
                output.Freeze();
                return output;
            }
            return new SolidColorBrush(Colors.Black);
        }

        /// <summary>
        /// <see cref="SolidColorBrush"/> to HSL hue
        /// </summary>
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                var color = brush.Color;
                return ColorCodeConverter.RGBToHSL(color.R, color.G, color.B).h;
            }
            return 0;
        }
    }
}
