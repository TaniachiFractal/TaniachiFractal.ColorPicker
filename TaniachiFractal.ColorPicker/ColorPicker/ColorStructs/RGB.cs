namespace TaniachiFractal.ColorPicker.ColorPicker.ColorStructs
{
    /// <summary>
    /// Has red, green and blue values
    /// </summary>
    internal class RGB
    {
        /// <summary>
        /// The red value
        /// </summary>
        public byte red;

        /// <summary>
        /// The green value
        /// </summary>
        public byte grn;

        /// <summary>
        /// The blue value
        /// </summary>
        public byte blu;

        /// <summary>
        /// The base constructor
        /// </summary>
        public RGB()
        {
            red = 0;
            grn = 0;
            blu = 0;
        }

        /// <summary>
        /// The constructor with 3 values
        /// </summary>
        public RGB(byte red, byte grn, byte blu)
        {
            this.red = red;
            this.grn = grn;
            this.blu = blu;
        }

        /// <summary>
        /// The constructor with a tuple
        /// </summary>
        public RGB((byte red, byte grn, byte blu) rgb)
        {
            red = rgb.red;
            grn = rgb.grn;
            blu = rgb.blu;
        }
    }
}
