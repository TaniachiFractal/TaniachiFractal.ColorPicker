using System.Windows.Controls;

namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// A HSL hue slider
    /// </summary>
    public partial class HueSlider : HSLControl
    {
        private double ColorSliderMidWidth;

        /// <summary>
        /// Constructor
        /// </summary>
        public HueSlider()
        {
            InitializeComponent();
        }

        /// <inheritdoc cref="HSLControl.OnColorsChanged()"/>
        protected override void OnColorsChanged()
        {
            base.OnColorsChanged();
            UpdX();
        }

        private void HSLControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ColorSliderMidWidth = Slider.ActualWidth / 2;
            DataContext = this;
            UpdX();
        }

        private void BindValueLabel()
        {

        }

        private void UpdX()
        {
            Canvas.SetLeft(Slider, Hue - ColorSliderMidWidth);
        }

        private void UpdHue(double x)
        {
            Hue = (byte)x;
            UpdX();
        }

        private void HSLControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                var position = e.GetPosition(this);
                var x = position.X;
                UpdHue(x);
            }
        }
    }
}
