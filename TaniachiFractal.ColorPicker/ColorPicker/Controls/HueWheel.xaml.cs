using System;
using System.Windows;
using System.Windows.Data;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// Interaction logic for HueWheel.xaml
    /// </summary>
    public partial class HueWheel : HSLControl
    {
        private const double wheelMiddle = 127;
        private const double radius = 113.5;

        private double ColorSliderMid;

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

        private void BindCS()
        {
            var satBind = new Binding(nameof(Saturation))
            {
                Source = this,
                Mode = BindingMode.OneWay,
            };
            CS.SetBinding(SaturationProperty, satBind);

            var litBind = new Binding(nameof(Lightness))
            {
                Source = this,
                Mode = BindingMode.OneWay,
            };
            CS.SetBinding(LightnessProperty, litBind);

            CS.DataContext = this;
        }

        private void HSLControl_Loaded(object sender, RoutedEventArgs e)
        {
            ColorSliderMid = CS.ActualWidth / 2;
            SetAngle(Hue);
            UpdXY();
            BindCS();
        }

        private void SetAngle(double x, double y)
            => Angle = Math.Atan2(y - wheelMiddle, x - wheelMiddle);

        private void SetAngle(byte hue)
            => Angle = hue.ToAngle();

        private void UpdXY()
        {
            (X, Y) = (radius * Math.Cos(Angle), radius * Math.Sin(Angle));
            X += wheelMiddle - ColorSliderMid;
            Y += wheelMiddle - ColorSliderMid;
        }

        private void UpdHue()
        {
            Hue = Angle.ToHue();
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

                SetAngle(x, y);
                UpdHue();
            }
        }

    }
}
