using System.Windows;
using TaniachiFractal.ColorPicker.ColorPicker.ColorStructs;

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
            ColorPicker.HSB = new HSB(60, 100, 100);
        }
    }
}
