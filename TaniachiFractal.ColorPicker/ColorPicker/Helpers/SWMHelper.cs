using System.Globalization;
using System.Windows.Data;
using System;
using System.Windows.Media;

namespace TaniachiFractal.ColorPicker.ColorPicker.Helpers
{
    /// <summary>
    /// Helper for <see cref="Brush"/>
    /// </summary>
    public static class SWMHelper
    {
        private const byte ContrastLimit = 110;

        /// <summary>
        /// Get the <see cref="SolidColorBrush"/> of the negative color, but if the negative is too similar to the original, shift it a bit
        /// </summary>
        public static SolidColorBrush ContrastNegative(this SolidColorBrush input)
        {
            var color = input.Color;
            var output = new SolidColorBrush(Color.FromRgb((byte)(Cnst.FF - color.R), (byte)(Cnst.FF - color.G), (byte)(Cnst.FF - color.B)));
            output.Freeze();
            return output;
        }

        /// <summary>
        /// HSL lightness to its contrasting black or white
        /// </summary>
        public static SolidColorBrush LightnessContrast(this byte Lightness)
        {
            var output = new SolidColorBrush(Colors.Black);
            if (Lightness < ContrastLimit)
            {
                output = new SolidColorBrush(Colors.White);
            }
            output.Freeze();
            return output;
        }

    }
}
