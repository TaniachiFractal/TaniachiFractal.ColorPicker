using System;

namespace TaniachiFractal.ColorPicker.ColorPicker
{
    /// <summary>
    /// Converts between RGB and HSL values
    /// </summary>
    public static class RgbToHsl
    {
        /// <summary>
        /// Convert HSL to RGB
        /// </summary>
        /// <param name="hue">color</param>
        /// <param name="sat">Saturation</param>
        /// <param name="lit">Lightness</param>
        /// <returns>A tuple with Red, Green and Blue values</returns>
        public static (byte r, byte g, byte b) ToRGB(byte hue, byte sat, byte lit)
        {
            double getVal(double VH, double V1, double V2)
            {
                if (VH < 0)
                { VH += 1; }
                if (VH > 1)
                { VH -= 1; }

                if (6 * VH < 1)
                { return V1 + (V2 - V1) * 6.0 * VH; }
                if (2 * VH < 1)
                { return V2; }
                if (3 * VH < 2)
                { return V1 + (V2 - V1) * (2.0 / 3.0 - VH) * 6.0; }
                return V1;
            }

            if (sat == 0)
            { return (lit, lit, lit); }

            var h = hue / 255.0;
            var s = sat / 255.0;
            var l = lit / 255.0;

            var v2 = l < 0.5 ? l * (1 + s) : (l + s) - (s * l);
            var v1 = 2.0 * l - v2;

            var r = getVal(h + 1.0 / 3.0, v1, v2) * 255.0;
            var g = getVal(h, v1, v2) * 255.0;
            var b = getVal(h - 1.0 / 3.0, v1, v2) * 255.0;

            return ((byte)r, (byte)g, (byte)b);
        }

        /// <summary>
        /// Convert HSL hue value to RGB
        /// </summary>
        /// <returns>The pure RGB value of the HSL hue</returns>
        public static (byte r, byte g, byte b) ToRGB(byte hue)
            => ToRGB(hue, 255, 128);

        /// <summary>
        /// From RGB to HSL
        /// </summary>
        /// <param name="red">Red</param>
        /// <param name="grn">Green</param>
        /// <param name="blu">Blue</param>
        /// <returns>A tuple with color, Saturation and Lightness values</returns>
        public static (byte h, byte s, byte l) ToHSL(byte red, byte grn, byte blu)
        {
            const double epsilon = 1e-5;

            var r = red / 255.0;
            var g = grn / 255.0;
            var b = blu / 255.0;

            var max = Math.Max(r, Math.Max(g, b));
            var min = Math.Min(r, Math.Min(g, b));
            var delta = (max + min) / 2;

            var h = 0.0;
            var s = 0.0;
            var l = (max - min) / 2;

            if (Math.Abs(delta) > epsilon)
            {
                if (l < 0.5)
                { s = delta / (max + min); }
                else
                { s = delta / (2 - max - min); }

                var dr = ((max - r) / 6 + delta / 2) / delta;
                var dg = ((max - g) / 6 + delta / 2) / delta;
                var db = ((max - b) / 6 + delta / 2) / delta;

                if (Math.Abs(r - max) < epsilon)
                { h = db - dg; }
                else if (Math.Abs(g - max) < epsilon)
                { h = 1.0 / 3.0 + dr - db; }
                else if (Math.Abs(b - r - max) < epsilon)
                { h = 2.0 / 3.0 + dg - dr; }

                if (h < 0)
                { h += 1; }
                if (h > 1)
                { h -= 1; }
            }

            var hue = (byte)(h * 255.0);
            var sat = (byte)(s * 255.0);
            var lit = (byte)(l * 255.0);

            return (hue, sat, lit);
        }   

    }
}
