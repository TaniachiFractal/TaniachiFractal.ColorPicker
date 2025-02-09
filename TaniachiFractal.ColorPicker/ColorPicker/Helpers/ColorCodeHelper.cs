using System;
using TaniachiFractal.ColorPicker.ColorPicker.ColorStructs;

namespace TaniachiFractal.ColorPicker.ColorPicker.Helpers
{
    /// <summary>
    /// Helps with RGB, HSB
    /// </summary>
    internal class ColorCodeHelper
    {
        /// <summary>
        /// Convert HSB to RGB
        /// </summary>
        /// <param name="hue">Hue</param>
        /// <param name="sat">Saturation</param>
        /// <param name="brt">Brightness</param>
        /// <returns>A tuple with RGB values</returns>
        public static (byte red, byte grn, byte blu) HsbToRgb(float hue, float sat, float brt)
        {
            var h = hue % 360;
            var s = sat / 100;
            var b = brt / 100;

            if (s == 0)
            {
                var gr = (byte)(b * 255);
                return (gr, gr, gr);
            }

            var chroma = b * s;

            var hNormal = h / 60;
            var hSmooth = chroma * (1 - Math.Abs((hNormal % 2) - 1));

            float red, grn, blu;

            if (hNormal < 1)
            { red = chroma; grn = hSmooth; blu = 0; }
            else if (hNormal < 2)
            { red = hSmooth; grn = chroma; blu = 0; }
            else if (hNormal < 3)
            { red = 0; grn = chroma; blu = hSmooth; }
            else if (hNormal < 4)
            { red = 0; grn = hSmooth; blu = chroma; }
            else if (hNormal < 5)
            { red = hSmooth; grn = 0; blu = chroma; }
            else
            { red = chroma; grn = 0; blu = hSmooth; }

            var bNormal = b - chroma;

            return
                (
                (byte)((red + bNormal) * 255),
                (byte)((grn + bNormal) * 255),
                (byte)((blu + bNormal) * 255)
                );

        }

        /// <summary>
        /// Convert <see cref="HSB"/> to <see cref="RGB"/>
        /// </summary>
        public static RGB HsbToRgb(HSB hsb)
            => new RGB(HsbToRgb(hsb.hue, hsb.sat, hsb.brt));

        /// <summary>
        /// Convert RGB to HSB
        /// </summary>
        /// <param name="red">Red</param>
        /// <param name="grn">Greeen</param>
        /// <param name="blu">Blue</param>
        /// <returns>A tuple with HSB values</returns>
        public static (float hue, float sat, float brt) RgbToHsb(byte red, byte grn, byte blu)
        {
            float hue, sat, brt;

            var r = red / 255f;
            var g = grn / 255f;
            var b = blu / 255f;

            var max = Math.Max(r, Math.Max(g, b));
            var min = Math.Min(r, Math.Min(g, b));
            var delta = max - min;

            brt = max;

            sat = max == 0 ? 0 : delta / max;

            if (max == min)
            { hue = 0; }
            else if (max == r)
            { hue = (g - b) / delta; }
            else if (max == g)
            { hue = 2 + (b - r) / delta; }
            else
            { hue = 4 + (r - g) / delta; }

            hue *= 60;
            hue %= 360;

            return (hue, sat, brt);
        }

        /// <summary>
        /// Convert <see cref="RGB"/> to <see cref="HSB"/>
        /// </summary>
        public static HSB RgbToHsb(RGB rgb)
            => new HSB(RgbToHsb(rgb.red, rgb.grn, rgb.blu));
    }
}
