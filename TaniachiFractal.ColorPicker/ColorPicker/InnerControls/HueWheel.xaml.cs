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
        private const byte SliderSize = 15;
        private const double Radius = 113.5;
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
                hw.OnAngleChanged();
            }
        }

        private void OnAngleChanged()
        {
            if (!ChangingVal)
            {
                ChangingVal = true;
                try
                {
                    UpdXY();
                }
                finally
                {
                    ChangingVal = false;
                }
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
            SliderCircle.Width = SliderCircle.Height = SliderSize;
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
            (X, Y) = (Radius * Math.Cos(Angle), Radius * Math.Sin(Angle));
            X += wheelMiddle - SliderCircleHalfWidth;
            Y += wheelMiddle - SliderCircleHalfHeight;
        }

        private void UpdAngle(double x, double y)
        {
            var angle = Math.Atan2(y - wheelMiddle, x - wheelMiddle);
            if (angle < 0)
            {
                angle += Cnst.Tau;
            }
            Angle = angle;
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
