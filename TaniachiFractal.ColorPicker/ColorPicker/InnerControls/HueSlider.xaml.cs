using System.Windows.Media;
using System.Windows.Media.Imaging;
using TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls
{
    /// <summary>
    /// A HSB hue slider
    /// </summary>
    public partial class HueSlider : HSBSlider
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HueSlider() : base()
        {
            InitializeComponent();
            SetImage();
        }

        /// <inheritdoc cref="HSBSlider.BindXtoHSB"/>
        protected override void BindXtoHSB()
        {
            BindHueToX.ConverterParameter = new double[] { Width, Cnst.MaxHue, SliderCircleHalfWidth };
            SetBinding(XProperty, BindHueToX);
        }

        private void SetImage()
        {
            RectLayer1.Fill = new ImageBrush()
            {
                ImageSource = (BitmapImage)Resources["HueStickPNG"]
            };
        }
    }
}
