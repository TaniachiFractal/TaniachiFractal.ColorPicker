namespace TaniachiFractal.ColorPicker.ColorPicker.ColorStructs
{
    /// <summary>
    /// Has hue, saturation and brightness values
    /// </summary>
    internal struct HSB
    {
        /// <summary>
        /// The hue value
        /// </summary>
        public float hue;

        /// <summary>
        /// The saturation value
        /// </summary>
        public float sat;

        /// <summary>
        /// The brightness value
        /// </summary>
        public float brt;

        /// <summary>
        /// The constructor with 3 values
        /// </summary>
        public HSB(float hue, float sat, float brt)
        {
            this.hue = hue;
            this.sat = sat;
            this.brt = brt;
        }

        /// <summary>
        /// The constructor with a tuple
        /// </summary>
        public HSB((float hue, float sat, float brt) hsb)
        {
            hue = hsb.hue;
            sat = hsb.sat;
            brt = hsb.brt;
        }
    }
}
