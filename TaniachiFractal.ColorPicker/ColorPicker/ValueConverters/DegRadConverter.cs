using System;
using System.Globalization;
using System.Windows.Data;

namespace TaniachiFractal.ColorPicker.ColorPicker.ValueConverters
{
    /// <summary>
    /// Converts between angles in rads and degrees
    /// </summary>
    public class DegRadConverter : IValueConverter
    {
        /// <summary>
        /// Deg to rad rad
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out var deg))
            {
                return deg * Cnst.RadDefCoef;
            }
            return 0;
        }

        /// <summary>
        /// Rad to deg rad
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out var rad))
            {
                return rad / Cnst.RadDefCoef;
            }
            return 0;
        }
    }
}
