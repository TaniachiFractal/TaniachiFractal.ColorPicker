using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace TaniachiFractal.ColorPicker.ColorPicker
{
    /// <summary>
    /// The square in the middle of the color picker, that is used to choose saturation and lightness of the color.
    /// </summary>
    public partial class SaturationLightnessSquare : UserControl, INotifyPropertyChanged
    {
        #region hue

        /// <summary>
        /// The HSL hue property
        /// </summary>
        public static readonly DependencyProperty HueProperty =
            DependencyProperty.Register(nameof(Hue), typeof(byte), typeof(SaturationLightnessSquare),
                new PropertyMetadata((byte)0));

        /// <inheritdoc cref="HueProperty"/>
        public byte Hue
        {
            get => (byte)GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }

        #endregion

        #region lightness

        /// <summary>
        /// The HSL lightness property
        /// </summary>
        public static readonly DependencyProperty LightnessProperty =
            DependencyProperty.Register(nameof(Lightness), typeof(byte), typeof(SaturationLightnessSquare),
                new PropertyMetadata((byte)0));

        /// <inheritdoc cref="LightnessProperty"/>
        public byte Lightness
        {
            get => (byte)GetValue(LightnessProperty);
            set => SetValue(LightnessProperty, value);
        }

        #endregion

        #region saturation

        /// <summary>
        /// The HSL saturation property
        /// </summary>
        public static readonly DependencyProperty SaturationProperty =
            DependencyProperty.Register(nameof(Saturation), typeof(byte), typeof(SaturationLightnessSquare),
                new PropertyMetadata((byte)0));

        /// <inheritdoc cref="SaturationProperty"/>
        public byte Saturation
        {
            get => (byte)GetValue(SaturationProperty);
            set => SetValue(SaturationProperty, value);
        }

        #endregion

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

        private bool MoveColorSlider(double x, double y)
        {
            const int ColorSliderDimen = 16;

            var maxX = Width - (ColorSliderDimen / 2);
            var maxY = Height - (ColorSliderDimen / 2);
            var minX = -ColorSliderDimen / 2;
            var minY = -ColorSliderDimen / 2;

            var setX = x - (ColorSliderDimen / 2);
            var setY = y - (ColorSliderDimen / 2);

            if (setX < maxX && setX > minX && setY < maxY && setY > minY)
            {
                Canvas.SetLeft(ColorSlider, setX);
                Canvas.SetTop(ColorSlider, setY);
                return true;
            }
            return false;
        }

        private void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => CaptureMouse();

        private void UserControl_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => ReleaseMouseCapture();

        private void UserControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                var position = e.GetPosition(this);
                var x = position.X;
                var y = position.Y;
                if (MoveColorSlider(x, y))
                {
                    Saturation = (byte)x;
                    Lightness = (byte)(128 - y);
                }


                test.Fill = RgbToHsl.ToRGB(Hue, Saturation, Lightness).ToBrush();
            }
        }
    }
}
