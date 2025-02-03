using System;
using System.Windows;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// Interaction logic for HueWheel.xaml
    /// </summary>
    public partial class HueWheel : HSLControl
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

        #region angle

        private double angle;

        /// <summary>
        /// The angle of the slider
        /// </summary>
        public double Angle
        {
            get => angle;
            set
            {
                if (angle != value)
                {
                    angle = value;
                    PropertyHasChanged();
                    Hue = angle.ToHue();
                }
            }
        }

        #endregion

        private const double wheelMiddle = 127;
        private const double radius = 113.5;

        /// <summary>
        /// Constructor
        /// </summary>
        public HueWheel()
        {
            InitializeComponent();
            DataContext = this;
            Saturation = Cnst.PureColorSaturation;
            Lightness = Cnst.PureColorLightness;
        }

        private void HSLControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetAngle(Hue);
            UpdXY();
        }

        private void SetAngle(double x, double y)
            => Angle = Math.Atan2(y, x);

        private void SetAngle(byte hue)
            => Angle = hue.ToAngle();

        private void UpdXY()
        {
            (X, Y) = (radius * Math.Cos(Angle), radius * Math.Sin(Angle));
            X += wheelMiddle - Cnst.ColorSliderMid;
            Y += wheelMiddle - Cnst.ColorSliderMid;
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

                SetAngle(x, y);
                UpdXY();
            }
        }

        
    }
}
