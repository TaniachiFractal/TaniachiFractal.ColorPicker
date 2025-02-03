using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// Interaction logic for ColorSlider.xaml
    /// </summary>
    public partial class ColorSlider : HSLControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ColorSlider()
        {
            InitializeComponent();
        }
    }
}
