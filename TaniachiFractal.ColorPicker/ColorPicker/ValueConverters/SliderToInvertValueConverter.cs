using System;
using System.Globalization;

namespace TaniachiFractal.ColorPicker.ColorPicker.ValueConverters
{
    /// <summary>
    /// Convert slider's X <see cref="double"/> value to another, but invert it
    /// </summary>
    internal class SliderToInvertValueConverter : SliderToValueConverter
    {
        /// <inheritdoc cref="SliderToInvertValueConverter"/>
        /// <param name="value">Slider's X <see cref="double"/> value</param>
        /// <param name="targetType">N/A</param>
        /// <param name="parameter"><see cref="double"/>[] 0: Slider width, 1: Max value, 2: Half circle width</param>
        /// <param name="culture">N/A</param>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is double[] args && args.Length == 3)
            {
                return args[1] - (double)base.Convert(value, targetType, parameter, culture) + 2 * args[2];
            }
            return base.Convert(value, targetType, parameter, culture);
        }

        /// <summary>
        /// Convert a value to the slider's X <see cref="double"/> value, bur invert it
        /// </summary>
        /// <param name="value">Some numeric value</param>
        /// <param name="targetType">N/A</param>
        /// <param name="parameter"><see cref="double"/>[] 0: Slider width, 1: Max value, 2: Half circle width</param>
        /// <param name="culture">N/A</param>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is double[] args && args.Length == 3)
            {
                return args[1] - (double)base.ConvertBack(value, targetType, parameter, culture);
            }
            return base.ConvertBack(value, targetType, parameter, culture);
        }
    }
}
