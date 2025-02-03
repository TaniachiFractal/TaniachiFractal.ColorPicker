namespace TaniachiFractal.ColorPicker.ColorPicker.Helpers
{
    /// <summary>
    /// Helper for Hue Wheel
    /// </summary>
    public static class HWHelper
    {
        /// <summary>
        /// Convert an angle in rads into a byte hue
        /// </summary>
        public static byte ToHue(this double angle)
            => (byte)(angle * 255);

        /// <summary>
        /// Convert a byte hue into an angle
        /// </summary>=
        public static double ToAngle(this byte Hue)
            => Hue / 255.0;
    }
}
