using System;

namespace TaniachiFractal.ColorPicker.ColorPicker
{
    /// <summary>
    /// Constants
    /// </summary>
    internal static class Cnst
    {
        /// <summary>
        /// Double Pi
        /// </summary>
        public const double Tau = Math.PI * 2;

        /// <summary>
        /// The max HSB hue value
        /// </summary>
        public const short MaxHue = 360;

        /// <summary>
        /// The max HSB sat value
        /// </summary>
        public const byte MaxSat = 100;

        /// <summary>
        /// The max HSB brt value
        /// </summary>
        public const byte MaxBrt = 100;

        /// <summary>
        /// Сoefficient between degrees and radians
        /// </summary>
        public const double RadDefCoef = Tau / MaxHue;
    }
}
