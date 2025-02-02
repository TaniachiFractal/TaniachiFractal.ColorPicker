using System.Windows;

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
            col.Hue = 0;
        }
    }
}
