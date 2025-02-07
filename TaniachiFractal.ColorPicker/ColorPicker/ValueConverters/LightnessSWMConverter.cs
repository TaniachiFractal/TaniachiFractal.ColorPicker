using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.ValueConverters
{
    /// <summary>
    /// Convert a HSL lightness to its contrasting black or white
    /// </summary>
    public class LightnessSWMConverter : IValueConverter
    {

        /// <inheritdoc cref="SWMHelper.LightnessContrast(byte)"/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte lit)
            {
                return lit.LightnessContrast();
            }
            return new SolidColorBrush();
        }

        /// <inheritdoc cref="Convert"/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Convert(value, targetType, parameter, culture);

    }
}
