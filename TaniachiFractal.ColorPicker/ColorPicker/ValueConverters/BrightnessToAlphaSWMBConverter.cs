using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.ValueConverters
{
    /// <summary>
    /// Convert HSB brightness value to transparent <see cref="SolidColorBrush"/>: Bright - transparent, Dim - opaque
    /// </summary>
    internal class BrightnessToAlphaSWMBConverter : IValueConverter
    {
        private const double BrtToAlpha = Cnst.MaxBrt / 255.0;

        /// <summary>
        /// Convert HSB brightness value to transparent <see cref="SolidColorBrush"/>: Bright - transparent, Dim - opaque
        /// </summary>
        /// <param name="value">Brightness value</param>
        /// <param name="targetType">N/A</param>
        /// <param name="parameter"><see cref="Color"/> of the brush</param>
        /// <param name="culture"></param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = Colors.Black;
            if (double.TryParse(value.ToString(), out var brt))
            {
                if (parameter is Color colorPar)
                {
                    color = colorPar;
                }
                var alpha = byte.MaxValue - brt / BrtToAlpha;
                color = Color.FromArgb((byte)alpha, color.R, color.G, color.B);
            }
            return color.ToBrush();
        }

        /// <summary>
        /// Get <see cref="SolidColorBrush"/> alpha value
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                return brush.Color.A / BrtToAlpha;
            }
            return 0;
        }
    }
}
