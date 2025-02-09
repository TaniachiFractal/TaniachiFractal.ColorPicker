using System.Windows.Media;

namespace TaniachiFractal.ColorPicker.ColorPicker.Helpers
{
    /// <summary>
    /// Helper for <see cref="Brush"/>
    /// </summary>
    internal static class SWMBHelper
    {
        /// <returns>A new <see cref="SolidColorBrush"/> in the frozen state</returns>
        public static SolidColorBrush NewSolidColorBrush(Color color)
        {
            var brush = new SolidColorBrush(color);
            brush.Freeze();
            return brush;
        }

        /// <summary>
        /// Convert RGB to <see cref="SolidColorBrush"/>
        /// </summary>
        /// <param name="rgbTuple">A tuple with Red, Green and Blue values</param>
        /// <returns>New frozen <see cref="SolidColorBrush"/> of the RGB color</returns>
        public static SolidColorBrush ToBrush(this (byte r, byte g, byte b) rgbTuple)
            => NewSolidColorBrush(Color.FromRgb(rgbTuple.r, rgbTuple.g, rgbTuple.b));

        private const byte ContrastVal = 120; 
        /// <returns>New frozen black or white <see cref="SolidColorBrush"/> 
        /// depending on what's more contrasting to the input color</returns>
        public static SolidColorBrush ContrastingRim(Color color)
            => (color.R + color.G + color.B) / 3 < ContrastVal ? NewSolidColorBrush(Colors.White) : NewSolidColorBrush(Colors.Black);
    }
}
