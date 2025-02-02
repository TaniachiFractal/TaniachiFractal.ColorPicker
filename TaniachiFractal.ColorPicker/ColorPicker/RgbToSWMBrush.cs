using System.Windows.Media;

namespace TaniachiFractal.ColorPicker.ColorPicker
{
    /// <summary>
    /// Convert RGB values to <see cref="SolidColorBrush"/>
    /// </summary>
    public static class RgbToSWMBrush
    {
        /// <summary>
        /// Convert RGB to <see cref="SolidColorBrush"/>
        /// </summary>
        /// <param name="rgbTuple">A tuple with Red, Green and Blue values</param>
        /// <returns><see cref="SolidColorBrush"/></returns>
        public static SolidColorBrush ToBrush(this (byte r, byte g, byte b) rgbTuple)
        {
            var output = new SolidColorBrush(Color.FromArgb(0xFF, rgbTuple.r, rgbTuple.g, rgbTuple.b));
            output.Freeze();
            return output;
        }
    }
}
