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
        /// <param name="parameter"><see cref="double"/>[] 0: Slider width, 1: Max value, 2: Half circle width</param>
        /// <param name="culture">N/A</param>
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out var x))
            {
                if (parameter is double[] args && args.Length == 3)
                {
                    return x * (args[0] / args[1]) - args[2];
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(parameter));
                }
            }
            return 0;
        }

        /// <summary>
        /// Convert a value to the slider's X <see cref="double"/> value
        /// </summary>
        /// <param name="value">Some numeric value</param>
        /// <param name="targetType">N/A</param>
        /// <param name="parameter"><see cref="double"/>[] 0: Slider width, 1: Max value, 2: Half circle width</param>
        /// <param name="culture">N/A</param>
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out var val))
            {
                if (parameter is double[] args && args.Length == 3)
                {
                    return val / (args[0] / args[1]);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(parameter));
                }
            }
            return 0;
        }
    }
}
