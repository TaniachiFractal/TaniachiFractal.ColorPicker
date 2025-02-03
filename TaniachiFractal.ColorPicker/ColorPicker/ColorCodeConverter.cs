using System;

namespace TaniachiFractal.ColorPicker.ColorPicker
{
    /// <summary>
    /// Converts between RGB, HSL, HSV
    /// </summary>
    public static class ColorCodeConverter
    {
        /// <summary>
        /// Convert HSL to RGB
        /// </summary>
        /// <param name="hue">color</param>
        /// <param name="sat">Saturation</param>
        /// <param name="lit">Lightness</param>
        /// <returns>A tuple with Red, Green and Blue values</returns>
        public static (byte r, byte g, byte b) HSLToRGB(byte hue, byte sat, byte lit)
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
        public static (byte r, byte g, byte b) HSLToRGB(byte hue)
            => HSLToRGB(hue, 255, 128);

        /// <summary>
        /// From RGB to HSL
        /// </summary>
        /// <param name="red">Red</param>
        /// <param name="grn">Green</param>
        /// <param name="blu">Blue</param>
        /// <returns>A tuple with color, Saturation and Lightness values</returns>
        public static (byte h, byte s, byte l) RGBToHSL(byte red, byte grn, byte blu)
        {
            double hue = 0, sat, lit;

            var r = red / 255.0;
            var g = grn / 255.0;
            var b = blu / 255.0;

            var max = Math.Max(r, Math.Max(g, b));
            var min = Math.Min(r, Math.Min(g, b));
            var delta = (max - min);

            lit = (max + min) / 2.0;

            if (delta == 0)
            { hue = 0; }
            else if (max == r)
            { hue = 60 * ((g - b) / delta) % 6; }
            else if (max == g)
            { hue = 60 * ((b - r) / delta + 2); }
            else if (max == b)
            { hue = 60 * ((r - g) / delta + 4); }

            if (delta == 0)
            { sat = 0; }
            else
            { sat = delta / (1 - Math.Abs(2 * lit - 1)); }

            var h = hue * (255.0 / 360.0);
            var s = sat * 255;
            var l = lit * 255;

            return ((byte)h, (byte)s, (byte)l);

        }

        /// <summary>
        /// From HSV to HSL
        /// </summary>
        /// <param name="hue">Hue</param>
        /// <param name="sat">Saturation</param>
        /// <param name="val">Value</param>
        /// <returns>A tuple with color, Saturation and Lightness values</returns>
        public static (byte h, byte s, byte l) HSVToHSL(byte hue, byte sat, byte val)
        {
            var l = val * (1 - (sat / 2.0));
            double s;

            if (l == 0 || l == 1)
            { s = 0; }
            else
            { s = (val - l) / Math.Min(l, 1 - l); }

            return (hue, (byte)l, (byte)s);
        }

    }
}
