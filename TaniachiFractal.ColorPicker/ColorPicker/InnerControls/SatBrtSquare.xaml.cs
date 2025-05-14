using System.Windows.Data;
using System.Windows;
using TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls;
using TaniachiFractal.ColorPicker.ColorPicker.ValueConverters;
using System.Windows.Input;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls
{
    /// <summary>
    /// A square to set HSB saturation and lightness
    /// </summary>
    public partial class SatBrtSquare : HSBColorSetter
    {
        private const byte SliderSize = 15;

        /// <summary>
        /// Constructor
        /// </summary>
        public SatBrtSquare()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Add bindings
        /// </summary>
        protected override void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            SliderCircle.Width = SliderCircle.Height = SliderSize;
            base.HSBControl_Loaded(sender, e);
            InitSliderCircle();
            BindXY();

            ImgRect.RadiusX = ImgRect.RadiusY = HueBackground.RadiusX = HueBackground.RadiusY = CornerRadius;
        }

        /// <inheritdoc cref="HSBColorSetter.UpdXY(double, double)"/>
        protected override void UpdXY(double x, double y)
        {
            X = x;
            Y = y;
        }

        private void BindXY()
        {
            var bindSat = new Binding(nameof(Sat))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Converter = new SliderToValueConverter(),
                ConverterParameter = new double[] { Width, Cnst.MaxSat, SliderCircleHalfWidth }
            };
            var bindBrt = new Binding(nameof(Brt))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Converter = new SliderToInvertValueConverter(),
                ConverterParameter = new double[] { Height, Cnst.MaxBrt, SliderCircleHalfHeight }
            };
            SetBinding(XProperty, bindSat);
            SetBinding(YProperty, bindBrt);
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
