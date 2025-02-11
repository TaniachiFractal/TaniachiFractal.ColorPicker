using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.ValueConverters
{
    /// <summary>
    /// Convert a <see cref="Brush"/> to its contrasting rim
    /// </summary>
    internal class ContrastingRimConverter : IValueConverter
    {
        /// <inheritdoc cref="SWMHelper.ContrastingRim(Color)"/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                return brush.Color.ContrastingRim();
            }
            return Colors.Black.ToBrush();
        }

        /// <inheritdoc cref="Convert"/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Convert(value, targetType, parameter, culture);
    }
}
