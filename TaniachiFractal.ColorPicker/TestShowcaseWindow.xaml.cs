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
            BindColorSquare();
        }

        private void BindColorSquare()
        {
            var bindSat = new Binding(nameof(SatLitSqr.Saturation))
            {
                Source = SatLitSqr,
                Mode = BindingMode.OneWay,
            };
            SatLabel.SetBinding(ContentProperty, bindSat);

            var bindLit = new Binding(nameof(SatLitSqr.Lightness))
            {
                Source = SatLitSqr,
                Mode = BindingMode.OneWay,
            };
            LitLabel.SetBinding(ContentProperty, bindLit);
        }
    }
}
