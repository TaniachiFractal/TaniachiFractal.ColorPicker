using System.Windows.Media;

namespace TaniachiFractal.ColorPicker.ColorPicker.Helpers
{
    /// <summary>
    /// Helper for <see cref="Brush"/>
    /// </summary>
    internal static class SWMBHelper
    {
        /// <returns>A new <see cref="SolidColorBrush"/> in the frozen state</returns>
        public static SolidColorBrush NewSolidColorBrush(this Color color)
        {
            var brush = new SolidColorBrush(color);
            brush.Freeze();
            return brush;
        }

        /// <summary>
        /// Convert RGB to <see cref="SolidColorBrush"/>
        /// </summary>
        /// <returns>New frozen <see cref="SolidColorBrush"/> of the RGB color</returns>
        public static SolidColorBrush ToBrush(this (byte red, byte grn, byte blu) rgb)
            => Color.FromRgb(rgb.red, rgb.grn, rgb.blu).NewSolidColorBrush();

        private const byte ContrastVal = 120;
        /// <returns>New frozen black or white <see cref="SolidColorBrush"/> 
        /// depending on what's more contrasting to the input color</returns>
        public static SolidColorBrush ContrastingRim(this Color color)
            => (color.R + color.G + color.B) / 3 < ContrastVal
            ? Colors.White.NewSolidColorBrush()
            : Colors.Black.NewSolidColorBrush();
    }
}
