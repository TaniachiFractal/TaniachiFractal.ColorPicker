using System.Windows;
using System.Windows.Media.Imaging;

namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// Parent for HSL sliders
    /// </summary>
    public partial class ParentSlider : HSLControl
    {
        /// <summary>
        /// The image property
        /// </summary>
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register(nameof(Image), typeof(BitmapImage), typeof(HSLControl),
                new PropertyMetadata(new BitmapImage()));

        /// <inheritdoc cref="ImageProperty"/>
        public byte Image
        {
            get => (byte)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ParentSlider()
        {
            InitializeComponent();
        }
    }
}
