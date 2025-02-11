using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls;
using TaniachiFractal.ColorPicker.ColorPicker.ValueConverters;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls
{
    /// <summary>
    /// A HSB hue slider wheel
    /// </summary>
    public partial class HueWheel : HSBColorSetter
    {
        private const byte sliderSize = 15;
        private const double radius = 113.5;
        private double wheelMiddle;

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

        /// <summary>
        /// Constructor
        /// </summary>
        public HueWheel()
        {
            InitializeComponent();
            DataContext = this;
            BindHueAngle();
        }

        /// <summary>
        /// Init slider circle
        /// </summary>=
        protected override void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            SliderCircle.Width = SliderCircle.Height = sliderSize;
            base.HSBControl_Loaded(sender, e);
            InitSliderCircle();
            wheelMiddle = ActualHeight / 2;
            UpdXY();
        }

        /// <inheritdoc cref="HSBColorSetter.UpdXY(double, double)"/>
        protected override void UpdXY(double x, double y)
        {
            UpdAngle(x, y);
        }

        /// <inheritdoc cref="HSBControl.CoerceHue(double)"/>
        protected override double CoerceHue(double hue)
        {
            if (hue > Cnst.MaxHue)
            {
                return hue % Cnst.MaxHue;
            }
            if (hue < -Cnst.MaxHue)
            {
                return Cnst.MaxHue + hue % Cnst.MaxHue;
            }
            if (hue < 0)
            {
                return Cnst.MaxHue + hue;
            }
            return hue;
        }

        private void BindHueAngle()
        {
            var bind = new Binding(nameof(Hue))
            {
                Source = DataContext,
                Mode = BindingMode.TwoWay,
                Converter = new DegRadConverter()
            };
            SetBinding(AngleProperty, bind);
        }

        private void UpdXY()
        {
            (X, Y) = (radius * Math.Cos(Angle), radius * Math.Sin(Angle));
            X += wheelMiddle - SliderCircleHalfWidth;
            Y += wheelMiddle - SliderCircleHalfHeight;
        }

        private void UpdAngle(double x, double y)
            => Angle = Math.Atan2(y - wheelMiddle, x - wheelMiddle);
    }
}
