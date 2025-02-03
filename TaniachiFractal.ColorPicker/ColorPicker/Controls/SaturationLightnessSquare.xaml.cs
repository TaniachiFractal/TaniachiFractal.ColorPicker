using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// The square in the middle of the color picker, that is used to choose saturation and lightness of the color.
    /// </summary>
    public partial class SaturationLightnessSquare : HSLControl
    {
        #region X

        private double x;

        /// <summary>
        /// The X coord of the slider
        /// </summary>
        public double X
        {
            get => x;
            set
            {
                if (x != value)
                {
                    x = value;
                    PropertyHasChanged();
                }
            }
        }

        #endregion

        #region Y

        private double y;

        /// <summary>
        /// The Y coord of the slider
        /// </summary>
        public double Y
        {
            get => y;
            set
            {
                if (y != value)
                {
                    y = value;
                    PropertyHasChanged();
                }
            }
        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public SaturationLightnessSquare()
        {
            InitializeComponent();
            DataContext = this;
            UpdXY();
        }

        private void UpdXY()
        {
            (X, Y) = SLSHelper.SatLitToCoord(Saturation, Lightness);
            X -= Cnst.ColorSliderMid;
            Y -= Cnst.ColorSliderMid;
        }

        private (double coercedX, double coercedY) UpdColorSlider(double x, double y)
        {
            var setX = x - Cnst.ColorSliderMid;
            var setY = y - Cnst.ColorSliderMid;

            if (setX > Cnst.SLSDimen)
            { setX = Cnst.SLSDimen; }
            if (setY > Cnst.SLSDimen)
            { setY = Cnst.SLSDimen; }

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

            var (sat, lit) = SLSHelper.CoordToSatLit(x, y);

            Saturation = sat;
            Lightness = lit;

            UpdXY();
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
