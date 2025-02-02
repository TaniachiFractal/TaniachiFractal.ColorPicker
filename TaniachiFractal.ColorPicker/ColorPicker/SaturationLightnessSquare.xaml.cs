using System.ComponentModel;
using System.Windows.Controls;

namespace TaniachiFractal.ColorPicker.ColorPicker
{
    /// <summary>
    /// The square in the middle of the color picker, that is used to choose saturation and lightness of the color.
    /// </summary>
    public partial class SaturationLightnessSquare : UserControl, INotifyPropertyChanged
    {
        private byte hue;

        /// <summary>
        /// The hue of the color in HSL
        /// </summary>
        public byte Hue
        {
            get => hue;
            set
            {
                if (hue != value)
                {
                    hue = value;
                    PropertyHasChanged();
                }
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SaturationLightnessSquare()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <inheritdoc cref="PropertyChangedEventHandler"/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invoke <see cref="PropertyChanged"/>
        /// </summary>
        protected void PropertyHasChanged() => PropertyChanged?.Invoke(this,
             new PropertyChangedEventArgs(null));
    }
}
