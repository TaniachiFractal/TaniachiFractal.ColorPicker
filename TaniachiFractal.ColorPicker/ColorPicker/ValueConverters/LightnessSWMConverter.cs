using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace TaniachiFractal.ColorPicker.ColorPicker.ValueConverters
{
    /// <summary>
    /// Convert a HSL lightness to its contrasting black or white
    /// </summary>
    public class LightnessSWMConverter : IValueConverter
    {
        private const byte ContrastLimit = 120;

        /// <summary>
        /// HSL lightness to its contrasting black or white
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var output = new SolidColorBrush(Colors.Black);
            if (value is byte lit)
            {
                if (lit < ContrastLimit)
                {
                    output = new SolidColorBrush(Colors.White);
                }
            }
            output.Freeze();
            return output;
        }

        /// <inheritdoc cref="Convert"/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Convert(value, targetType, parameter, culture);

    }
}
