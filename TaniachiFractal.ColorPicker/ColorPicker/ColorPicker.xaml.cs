using TaniachiFractal.ColorPicker.ColorPicker.InnerControls;
using TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls;

namespace TaniachiFractal.ColorPicker.ColorPicker
{
    /// <summary>
    /// HSB color picker
    /// </summary>
    public partial class ColorPicker : HSBControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ColorPicker()
        {
            InitializeComponent();

            DataContext = this;

            BindChildren();

        }

        private void BindChildren()
        {
            HueWheel.SetBinding(HueProperty, BindHue);
            HueWheel.SetBinding(SatProperty, BindSat);
            HueWheel.SetBinding(BrtProperty, BindBrt);

            SatBrtSquare.SetBinding(HueProperty, BindHue);
            SatBrtSquare.SetBinding(SatProperty, BindSat);
            SatBrtSquare.SetBinding(BrtProperty, BindBrt);

            HueSlider.SetBinding(HueProperty, BindHue);
            HueSlider.SetBinding(SatProperty, BindSat);
            HueSlider.SetBinding(BrtProperty, BindBrt);

            SatSlider.SetBinding(HueProperty, BindHue);
            SatSlider.SetBinding(SatProperty, BindSat);
            SatSlider.SetBinding(BrtProperty, BindBrt);

            BrtSlider.SetBinding(HueProperty, BindHue);
            BrtSlider.SetBinding(SatProperty, BindSat);
            BrtSlider.SetBinding(BrtProperty, BindBrt);
        }

        #region change val

        /// <summary>
        /// Change <see cref="HSBControl.Hue"/> by <paramref name="delta"/>
        /// </summary>
        public void ChangeHue(int delta) => Hue = ChangeVal(Hue, Cnst.MaxHue, delta);

        /// <summary>
        /// Change <see cref="HSBControl.Sat"/> by <paramref name="delta"/>
        /// </summary>
        public void ChangeSat(int delta) => Sat = ChangeVal(Sat, Cnst.MaxSat, delta);

        /// <summary>
        /// Change <see cref="HSBControl.Brt"/> by <paramref name="delta"/>
        /// </summary>
        public void ChangeBrt(int delta) => Brt = ChangeVal(Brt, Cnst.MaxBrt, delta);

        private double ChangeVal(double val, short max, int delta)
        {
            val = (int)val;

            if (val == max && delta > 0)
            { return 0; }

            if (val == 0 && delta < 0)
            { return max; }

            val += delta;
            if (val < 0)
            {
                val = max + val;
            }
            if (val > max)
            {
                val -= max;
            }
            return val;
        }

        #endregion

        /// <summary>
        /// Freeze old color
        /// </summary>
        protected override void HSBControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            base.HSBControl_Loaded(sender, e);

            SetOldColor();
        }

        /// <summary>
        /// Set the old color view
        /// </summary>
        public void SetOldColor()
        {
            OldColor.DataContext = new HSBShowColor() { Hue = Hue, Sat = Sat, Brt = Brt };
        }

        private void HexTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            HexTextBox.Text = HexTextBox.Text.ToUpper();
        }

    }
}
