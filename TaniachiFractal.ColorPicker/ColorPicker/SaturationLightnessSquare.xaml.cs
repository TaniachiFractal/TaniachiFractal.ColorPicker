using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace TaniachiFractal.ColorPicker.ColorPicker
{
    /// <summary>
    /// The square in the middle of the color picker, that is used to choose saturation and lightness of the color.
    /// </summary>
    public partial class SaturationLightnessSquare : UserControl
    {
        private const byte FF = 255;
        private const byte width = 128;

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
        /// Constructor
        /// </summary>
        public SaturationLightnessSquare()
        {
            InitializeComponent();
            DataContext = this;
        }

        private (double coercedX, double coercedY) UpdColorSlider(double x, double y)
        {
            const int ColorSliderMid = 16 / 2;

            var maxX = Width - ColorSliderMid;
            var maxY = Height - ColorSliderMid;
            var minX = -ColorSliderMid;
            var minY = -ColorSliderMid;

            var setX = x - ColorSliderMid;
            var setY = y - ColorSliderMid;

            if (setX > maxX)
            { setX = maxX; }

            if (setY > maxY)
            { setY = maxY; }

            if (setX < minX)
            { setX = minX; }

            if (setY < minY)
            { setY = minY; }

            Canvas.SetLeft(ColorSlider, setX);
            Canvas.SetTop(ColorSlider, setY);

            var corX = setX;
            var corY = setY;

            if (corX > 128)
            { corX = 128; }
            if (corY > 128)
            { corY = 128; }
            if (corX < 0)
            { corX = 0; }
            if (corY < 0)
            { corY = 0; }

            return (corX, corY);
        }

        private void UpdSatLit(double x, double y)
        {
            (x, y) = UpdColorSlider(x, y);

            var (sat, lit) = CoordToSatLit(x, y);

            Saturation = sat;
            Lightness = lit;

            test.Fill = ColorCodeConverter.HSLToRGB(Hue, Saturation, Lightness).ToBrush();
        }

        //private static (double x,  double y) SatLitToCoord(byte sat, byte lit)
        //{
        //    var x = width * FF * sat;
        //}

        private static (byte sat, byte lit) CoordToSatLit(double x, double y)
        {
            var sat = x / width * FF;

            var litMul = 1 - sat / (2 * FF);
            var lit = (FF - y / width * FF) * litMul;

            return ((byte)sat, (byte)lit);
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
                UpdSatLit(x, y);
            }
        }

    }
}
