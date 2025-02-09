namespace TaniachiFractal.ColorPicker.ColorPicker.ColorStructs
{
    /// <summary>
    /// Has hue, saturation and brightness values
    /// </summary>
    public class HSB
    {
        #region hue

        private float hue;

        /// <summary>
        /// The hue value
        /// </summary>
        public float Hue
        {
            get => hue;
            set
            {
                hue = value % (Cnst.MaxHue + 1);
            }
        }

        #endregion

        #region sat

        private float sat;

        /// <summary>
        /// The saturation value
        /// </summary>
        public float Sat
        {
            get => sat;
            set
            {
                sat = value % (Cnst.MaxSat + 1);
            }
        }

        #endregion

        #region brt

        private float brt;

        /// <summary>
        /// The brightness value
        /// </summary>
        public float Brt
        {
            get => brt;
            set
            {
                brt = value % (Cnst.MaxBrt + 1);
            }
        }

        #endregion

        /// <summary>
        /// The base constructor
        /// </summary>
        public HSB()
        {
            hue = 0; sat = 0; brt = 0;
        }

        /// <summary>
        /// The constructor with 3 values
        /// </summary>
        public HSB(float hue, float sat, float brt)
        {
            Hue = hue;
            Sat = sat;
            Brt = brt;
        }

        /// <summary>
        /// The constructor with a tuple
        /// </summary>
        public HSB((float hue, float sat, float brt) hsb)
        {
            Hue = hsb.hue;
            Sat = hsb.sat;
            Brt = hsb.brt;
        }
    }
}
