using System;
using System.Globalization;
using System.Windows.Data;

namespace TaniachiFractal.ColorPicker.ColorPicker.ValueConverters
{
    /// <summary>
    /// Convert slider's X <see cref="double"/> value to another
    /// </summary>
    internal class SliderToValueConverter : IValueConverter
    {
        /// <inheritdoc cref="SliderToValueConverter"/>
        /// <param name="value">Slider's X <see cref="double"/> value</param>
        /// <param name="targetType">N/A</param>
        /// <param name="parameter"><see cref="double"/>[] 0: Slider width, 1: Max value</param>
        /// <param name="culture">N/A</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double x)
            {
                return x * GetConversionRate(parameter);
            }
            return 0;
        }

        /// <summary>
        /// Convert a value to the slider's X <see cref="double"/> value
        /// </summary>
        /// <param name="value">Some numeric value</param>
        /// <param name="targetType">N/A</param>
        /// <param name="parameter"><see cref="double"/>[] 0: Slider width, 1: Max value</param>
        /// <param name="culture">N/A</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out var val))
            {
                return val / GetConversionRate(parameter);
            }
            return 0;
        }

        /// <param name="parameter"><see cref="double"/>[] 0: Slider width, 1: Max value</param>
        private static double GetConversionRate(object parameter)
        {
            if (parameter is double[] args && args.Length == 2)
            {
                var conversionRate = args[0] / args[1];

                return conversionRate;
            }
            return 0;
        }
    }
}
