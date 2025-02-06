using System.Diagnostics;
using System.Windows.Data;

namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : HSLControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ColorPicker()
        {
            InitializeComponent();
            BindCPtoHWandSLS();
            Debug.Write("Color picker by https://github.com/TaniachiFractal/ \n");
        }

        private void BindCPtoHWandSLS()
        {
            var bindHue = new Binding(nameof(Hue))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
            };

            var bindSat = new Binding(nameof(Saturation))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
            };

            var bindLit = new Binding(nameof(Lightness))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
            };

            HW.SetBinding(HueProperty, bindHue);
            HW.SetBinding(SaturationProperty, bindSat);
            HW.SetBinding(LightnessProperty, bindLit);

            SLS.SetBinding(HueProperty, bindHue);
            SLS.SetBinding(SaturationProperty, bindSat);
            SLS.SetBinding(LightnessProperty, bindLit);
        }
    }
}
