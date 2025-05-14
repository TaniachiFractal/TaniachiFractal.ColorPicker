using System.Windows.Media;

namespace TaniachiFractal.ColorPicker.ColorPicker.Helpers
{
    /// <summary>
    /// Helper for <see cref="System.Windows.Media"/>
    /// </summary>
    static internal class SWMHelper
    {
        /// <returns>A new <see cref="SolidColorBrush"/> in the frozen state</returns>
        public static SolidColorBrush ToBrush(this Color color)
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
            => Color.FromRgb(rgb.red, rgb.grn, rgb.blu).ToBrush();

        private const byte ContrastVal = 60;
        private const byte DarkRim = 40, LightRim = 120;
        /// <returns>New frozen black or white <see cref="SolidColorBrush"/> 
        /// depending on what's more contrasting to the input color</returns>
        public static SolidColorBrush ContrastingRim(this Color color)
            => (color.R + color.G + color.B) / 3 < ContrastVal
            ? Color.FromRgb(LightRim, LightRim, LightRim).ToBrush()
            : Color.FromRgb(DarkRim, DarkRim, DarkRim).ToBrush();

        /// <summary>
        /// <see cref="Color"/> to HSB
        /// </summary>
        public static (double hue, double sat, double brt) ToHSB(this Color color)
            => ColorCodeHelper.RgbToHsb(color.R, color.B, color.G);
    }
}
