using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls;
using TaniachiFractal.ColorPicker.ColorPicker.ValueConverters;

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

        /// <summary>
        /// Add bindings
        /// </summary>
        protected override void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            base.HSBControl_Loaded(sender, e);
            BindX();
        }

        private void BindX()
        {
            var bind = new Binding(nameof(Hue))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Converter = new SliderToValueConverter(),
                ConverterParameter = new double[] { Width, Cnst.MaxHue, SliderCircleHalfWidth }
            };
            SetBinding(XProperty, bind);
        }

        private void SetImage()
        {
            RectLayer1.Background = new ImageBrush()
            {
                ImageSource = (BitmapImage)Resources["HueStickPNG"]
            };
        }
    }
}
