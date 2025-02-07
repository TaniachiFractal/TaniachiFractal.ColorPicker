namespace TaniachiFractal.ColorPicker.ColorPicker.Helpers
{
    /// <summary>
    /// Helper for SaturationLightnessSquare
    /// </summary>
    public static class SLSHelper
    {
        /// <summary>
        /// Saturation and lightness to SLS coords
        /// </summary>
        public static (double x, double y) SatLitToCoord(byte sat, byte lit, double width, double height)
        {
            var x = sat * width / Cnst.FF;
            var y = Cnst.FF - (height * (Cnst.FF + (lit / LitMul(sat))) / Cnst.FF);

            if (y < 0)
            {
                y = 0;
            }

            return (x, y);
        }

        /// <summary>
        /// SLS coords to saturation and lightness
        /// </summary>
        public static (byte sat, byte lit) CoordToSatLit(double x, double y, double width, double height)
        {
            var sat = x / width * Cnst.FF;
            var lit = (Cnst.FF - (y / height * Cnst.FF)) * LitMul(sat);

            return ((byte)sat, (byte)lit);
        }

        private static double LitMul(double sat)
            => 1 - (sat / (2 * Cnst.FF));

    }
}
