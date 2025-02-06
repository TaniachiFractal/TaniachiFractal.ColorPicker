using System;

namespace TaniachiFractal.ColorPicker.ColorPicker
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Cnst
    {
        /// <summary>
        /// byte.MaxValue = 255
        /// </summary>
        public const byte FF = 255;

        /// <summary>
        /// Max rad angle / 255 = 2Pi/255
        /// </summary>
        public const double AngleHue = (2 * Math.PI) / FF;

        /// <summary>
        /// The lightness of a pure hue color
        /// </summary>
        public const byte PureColorLightness = 127;

        /// <summary>
        /// The saturation of a pure hue color
        /// </summary>
        public const byte PureColorSaturation = 255;
    }
}
