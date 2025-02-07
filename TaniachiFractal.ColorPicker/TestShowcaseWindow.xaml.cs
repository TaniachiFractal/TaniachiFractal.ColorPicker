using System.Windows;
using System.Windows.Data;

namespace TaniachiFractal.ColorPicker
{
    /// <summary>
    /// Interaction logic for TestShowcaseWindow.xaml
    /// </summary>
    public partial class TestShowcaseWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TestShowcaseWindow()
        {
            InitializeComponent();
            BindLabels();
        }

        private void BindLabels()
        {
            var bindHue = new Binding(nameof(ColorPicker.Hue))
            {
                Source = ColorPicker,
                Mode = BindingMode.TwoWay,
            };

            var bindSat = new Binding(nameof(ColorPicker.Saturation))
            {
                Source = ColorPicker,
                Mode = BindingMode.TwoWay,
            };

            var bindLit = new Binding(nameof(ColorPicker.Lightness))
            {
                Source = ColorPicker,
                Mode = BindingMode.TwoWay,
            };

            HueLabel.SetBinding(ContentProperty, bindHue);
            SatLabel.SetBinding(ContentProperty, bindSat);
            LitLabel.SetBinding(ContentProperty, bindLit);
        }
    }
}
