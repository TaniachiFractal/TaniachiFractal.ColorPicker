using System;
using System.Globalization;
using System.Windows.Data;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.ValueConverters
{
    /// <summary>
    /// Converts between angles in rads and byte hues
    /// </summary>
    public class HueAngleConverter : IValueConverter
    {
        /// <summary>
        /// Byte hue to rad angle
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte hue)
            {
                return hue * Cnst.AngleHue;
            }
            return 0;
        }

        /// <summary>
        /// Rad angle to hue
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double angle)
            {
                return (byte)(angle / Cnst.AngleHue);
            }
            return 0;
        }
    }
}
