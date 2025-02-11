using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.ValueConverters
{
    /// <summary>
    /// Convert HSB hue to its pure color <see cref="SolidColorBrush"/>
    /// </summary>
    internal class HueToSWMBConverter : IValueConverter
    {
        /// <summary>
        /// Convert HSB hue to its pure color <see cref="SolidColorBrush"/>
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out var hue))
            {
                return hue.HsbHueToRgb().ToBrush();
            }
            return Colors.Black.ToBrush();
        }

        /// <summary>
        /// Convert <see cref="SolidColorBrush"/> to its pure color hue
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                var color = brush.Color;
                return ColorCodeHelper.RgbToHsb(color.R, color.G, color.B).hue;
            }
            return 0;
        }
    }
}
