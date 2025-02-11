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

        /// <summary>
        /// Freeze old color
        /// </summary>
        protected override void HSBControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            base.HSBControl_Loaded(sender, e);

            OldColor.DataContext = new HSBShowColor() { Hue = Hue, Sat = Sat, Brt = Brt };
        }
    }
}
