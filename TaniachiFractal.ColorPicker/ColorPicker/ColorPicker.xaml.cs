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

            OldColor.Hue = Hue;
            OldColor.Sat = Sat;
            OldColor.Brt = Brt;
        }

        private void BindChildren()
        {
            ShowColor.SetBinding(HueProperty, BindHue);
            ShowColor.SetBinding(SatProperty, BindSat);
            ShowColor.SetBinding(BrtProperty, BindBrt);

            HueSlider.SetBinding(HueProperty, BindHue);
            HueSlider.SetBinding(SatProperty, BindSat);
            HueSlider.SetBinding(BrtProperty, BindBrt);

            hue.SetBinding(ContentProperty, BindHue);
        }


    }
}
