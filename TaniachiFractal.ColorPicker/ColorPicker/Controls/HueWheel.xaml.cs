using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TaniachiFractal.ColorPicker.ColorPicker.ValueConverters;

namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// Interaction logic for HueWheel.xaml
    /// </summary>
    public partial class HueWheel : HSLControl
    {
        #region angle

        /// <summary>
        /// The angle property
        /// </summary>
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register(nameof(Angle), typeof(double), typeof(HueWheel),
                new PropertyMetadata(0.0, OnAngleChanged));

        /// <inheritdoc cref="AngleProperty"/>
        public double Angle
        {
            get => (double)GetValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        }

        private static void OnAngleChanged(DependencyObject dependObj, DependencyPropertyChangedEventArgs evArgs)
        {
            if (dependObj is HueWheel hw)
            {
                hw.UpdXY();
            }
        }

        #endregion

        private const double wheelMiddle = 127;
        private const double radius = 113.5;

        private double ColorSliderMidWidth;
        private double ColorSliderMidHeight;
        private double X;
        private double Y;

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

        /// <inheritdoc cref="HSLControl.OnColorsChanged()"/>
        protected override void OnColorsChanged()
        {
            base.OnColorsChanged();
            UpdXY();
        }

        private void HSLControl_Loaded(object sender, RoutedEventArgs e)
        {
            ColorSliderMidWidth = CS.ActualWidth / 2;
            ColorSliderMidHeight = CS.ActualHeight / 2;
            UpdXY();
            BindHue();
        }

        private void BindHue()
        {
            var bind = new Binding(nameof(Hue))
            {
                Source = DataContext,
                Mode = BindingMode.TwoWay,
                Converter = new HueAngleConverter()
            };
            SetBinding(AngleProperty, bind);
        }

        private void SetAngle(double x, double y)
            => Angle = Math.Atan2(y - wheelMiddle, x - wheelMiddle);

        private void UpdXY()
        {
            (X, Y) = (radius * Math.Cos(Angle), radius * Math.Sin(Angle));
            X += wheelMiddle - ColorSliderMidWidth;
            Y += wheelMiddle - ColorSliderMidHeight;
            Canvas.SetLeft(CS, X);
            Canvas.SetTop(CS, Y);
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
