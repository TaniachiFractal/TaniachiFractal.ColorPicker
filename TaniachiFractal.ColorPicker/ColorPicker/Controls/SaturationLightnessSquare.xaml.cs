using System.Windows.Controls;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// The square in the middle of the color picker, that is used to choose saturation and lightness of the color.
    /// </summary>
    public partial class SaturationLightnessSquare : HSLControl
    {
        private double ColorSliderMidHeight;
        private double ColorSliderMidWidth;
        private double X;
        private double Y;

        /// <summary>
        /// Constructor
        /// </summary>
        public SaturationLightnessSquare()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <inheritdoc cref="HSLControl.OnColorsChanged()"/>
        protected override void OnColorsChanged()
        {
            base.OnColorsChanged();
            UpdXY();
        }

        private void HSLControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ColorSliderMidHeight = Slider.ActualHeight / 2;
            ColorSliderMidWidth = Slider.ActualWidth / 2;
            UpdXY();
        }

        private void UpdXY()
        {
            (X, Y) = SLSHelper.SatLitToCoord(Saturation, Lightness, Width, Height);
            X -= ColorSliderMidWidth;
            Y -= ColorSliderMidHeight;

            Canvas.SetLeft(Slider, X);
            Canvas.SetTop(Slider, Y);
        }

        private (double coercedX, double coercedY) UpdColorSlider(double x, double y)
        {
            var setX = x - ColorSliderMidHeight;
            var setY = y - ColorSliderMidHeight;

            if (setX > ActualWidth)
            { setX = ActualWidth; }
            if (setY > ActualHeight)
            { setY = ActualHeight; }

            X = setX;
            Y = setY;

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

            var (sat, lit) = SLSHelper.CoordToSatLit(x, y, Width, Height);

            Saturation = sat;
            Lightness = lit;

            UpdXY();
        }

        private void HSLControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
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
