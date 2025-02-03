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
        public static (double x, double y) SatLitToCoord(byte sat, byte lit, double SLSDimen)
        {
            var x = sat * SLSDimen / Cnst.FF;
            var y = Cnst.FF - SLSDimen * (Cnst.FF + (lit / LitMul(sat))) / Cnst.FF;

            return (x, y);
        }

        /// <summary>
        /// SLS coords to saturation and lightness
        /// </summary>
        public static (byte sat, byte lit) CoordToSatLit(double x, double y, double SLSDimen)
        {
            var sat = x / SLSDimen * Cnst.FF;
            var lit = (Cnst.FF - (y / SLSDimen * Cnst.FF)) * LitMul(sat);

            return ((byte)sat, (byte)lit);
        }

        private static double LitMul(double sat)
            => 1 - (sat / (2 * Cnst.FF));

    }
}
