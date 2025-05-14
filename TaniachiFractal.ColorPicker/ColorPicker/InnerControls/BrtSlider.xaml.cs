using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls;
using TaniachiFractal.ColorPicker.ColorPicker.ValueConverters;
using System.Windows.Input;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls
{
    /// <summary>
    /// A HSB brightness slider
    /// </summary>
    public partial class BrtSlider : HSBSlider
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BrtSlider()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add bindings
        /// </summary>
        protected override void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            base.HSBControl_Loaded(sender, e);
            BindX();
            BindHueRect();
            BindSatRect();
            SetImage();
        }

        private void BindX()
        {
            var bind = new Binding(nameof(Brt))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Converter = new SliderToValueConverter(),
                ConverterParameter = new double[] { Width, Cnst.MaxBrt, SliderCircleHalfWidth }
            };
            SetBinding(XProperty, bind);
        }

        private void BindHueRect()
        {
            var bind = new Binding(nameof(Hue))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Converter = new HueToSWMBConverter(),
            };
            RectLayer1.SetBinding(BackgroundProperty, bind);
        }

        private void BindSatRect()
        {
            var bind = new Binding(nameof(Sat))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Converter = new BrightnessToAlphaSWMBConverter(),
                ConverterParameter = Colors.White,
            };
            RectLayer2.SetBinding(BackgroundProperty, bind);
        }

        private void SetImage()
        {
            RectLayer3.Background = new ImageBrush()
            {
                ImageSource = (BitmapImage)Resources["BrtStickPNG"]
            };
        }

        /// <inheritdoc/>
        protected override void HSBControl_MouseDown(object sender, MouseButtonEventArgs e)
            => base.HSBControl_MouseDown(sender, e);

        /// <inheritdoc/>
        protected override void HSBControl_MouseMove(object sender, MouseEventArgs e)
            => base.HSBControl_MouseMove(sender, e);

        /// <inheritdoc/>
        protected override void HSBControl_MouseUp(object sender, MouseButtonEventArgs e)
            => base.HSBControl_MouseUp(sender, e);
    }
}
