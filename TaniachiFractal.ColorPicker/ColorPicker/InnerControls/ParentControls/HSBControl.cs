using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls
{
    /// <summary>
    /// A control with Hue, Saturation and Brightness properties
    /// </summary>
    public class HSBControl : UserControl
    {
        /// <summary>
        /// The root control
        /// </summary>
        protected Panel RootControl;

        /// <summary>
        /// Constructor: Create the HSB bindings
        /// </summary>
        public HSBControl()
        {
            BindHue = new Binding(nameof(Hue))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
            };

            BindSat = new Binding(nameof(Sat))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
            };

            BindBrt = new Binding(nameof(Brt))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
            };
        }

        /// <summary>
        /// Load root control
        /// </summary>
        protected virtual void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Content is Panel fe)
            { RootControl = fe; }
        }

        private static float Coerce(float val, short maxVal)
        {
            val %= maxVal + 1;
            val = val < 0 ? maxVal - val : val;
            return val;
        }

        #region bind

        /// <summary>
        /// <see cref="Binding"/> to <see cref="Hue"/>
        /// </summary>
        protected Binding BindHue;
        /// <summary>
        /// <see cref="Binding"/> to <see cref="Sat"/>
        /// </summary>
        protected Binding BindSat;
        /// <summary>
        /// <see cref="Binding"/> to <see cref="Brt"/>
        /// </summary>
        protected Binding BindBrt;

        #endregion

        #region hue

        /// <summary>
        /// The HSB hue property
        /// </summary>
        public static readonly DependencyProperty HueProperty =
            DependencyProperty.Register(nameof(Hue), typeof(float), typeof(HSBControl),
                new PropertyMetadata(0F, OnColorsChanged, CoerceHue));

        /// <inheritdoc cref="HueProperty"/>
        public float Hue
        {
            get => (float)GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }

        private static object CoerceHue(DependencyObject dependObj, object value)
        {
            if (value is float val)
            {
                return Coerce(val, Cnst.MaxHue);
            }
            return 0;
        }

        #endregion

        #region sat

        /// <summary>
        /// The HSB saturation property
        /// </summary>
        public static readonly DependencyProperty SatProperty =
            DependencyProperty.Register(nameof(Sat), typeof(float), typeof(HSBControl),
                new PropertyMetadata(0F, OnColorsChanged, CoerceSat));

        /// <inheritdoc cref="SatProperty"/>
        public float Sat
        {
            get => (float)GetValue(SatProperty);
            set => SetValue(SatProperty, value);
        }

        private static object CoerceSat(DependencyObject dependObj, object value)
        {
            if (value is float val)
            {
                return Coerce(val, Cnst.MaxSat);
            }
            return 0;
        }

        #endregion

        #region brt

        /// <summary>
        /// The HSB brightness property
        /// </summary>
        public static readonly DependencyProperty BrtProperty =
            DependencyProperty.Register(nameof(Brt), typeof(float), typeof(HSBControl),
                new PropertyMetadata(0F, OnColorsChanged, CoerceBrt));

        /// <inheritdoc cref="BrtProperty"/>
        public float Brt
        {
            get => (float)GetValue(BrtProperty);
            set => SetValue(BrtProperty, value);
        }

        private static object CoerceBrt(DependencyObject dependObj, object value)
        {
            if (value is float val)
            {
                return Coerce(val, Cnst.MaxBrt);
            }
            return 0;
        }

        #endregion

        #region corner radius

        /// <summary>
        /// The corner radius property
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(double), typeof(HSBControl),
                new PropertyMetadata(0.0));

        /// <inheritdoc cref="CornerRadiusProperty"/>
        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        #endregion

        #region brush

        /// <summary>
        /// The SolidColorBrush/Color/Fill property
        /// </summary>
        public static readonly DependencyProperty BrushProperty =
            DependencyProperty.Register(nameof(Brush), typeof(SolidColorBrush), typeof(HSBControl),
                new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <inheritdoc cref="BrushProperty"/>
        public SolidColorBrush Brush
        {
            get => (SolidColorBrush)GetValue(BrushProperty);
            private set => SetValue(BrushProperty, value);
        }

        #endregion

        #region on colors changed

        private static void OnColorsChanged(DependencyObject dependObj, DependencyPropertyChangedEventArgs evArgs)
        {
            if (dependObj is HSBControl con)
            {
                con.OnColorsChanged();
            }
        }

        /// <summary>
        /// Method to invoke upon changing HSL values
        /// </summary>
        protected virtual void OnColorsChanged()
        {
            Brush = (Hue, Sat, Brt).HsbToRgb().ToBrush();
        }

        #endregion
    }
}
