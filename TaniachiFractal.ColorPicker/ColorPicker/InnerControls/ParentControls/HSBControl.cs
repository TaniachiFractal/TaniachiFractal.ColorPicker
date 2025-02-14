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
        private const double defaultHue = 0;
        private const double defaultSat = 100;
        private const double defaultBrt = 100;

        /// <summary>
        /// The root control
        /// </summary>
        protected Panel RootControl;

        /// <summary>
        /// If the control is in the process of changing its values
        /// </summary>
        protected bool ChangingVal = false;

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

        private static double CoerceHSB(double val, short maxVal)
        {
            if (val > maxVal)
            {
                return maxVal;
            }
            if (val < 0)
            {
                return 0;
            }
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
            DependencyProperty.Register(nameof(Hue), typeof(double), typeof(HSBControl),
                new PropertyMetadata(defaultHue, OnColorsChanged, CoerceHue));

        /// <inheritdoc cref="HueProperty"/>
        public double Hue
        {
            get => (double)GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }

        private static object CoerceHue(DependencyObject dependObj, object value)
        {
            if (value is double val)
            {
                return CoerceHSB(val, Cnst.MaxHue);
            }
            return 0;
        }

        #endregion

        #region sat

        /// <summary>
        /// The HSB saturation property
        /// </summary>
        public static readonly DependencyProperty SatProperty =
            DependencyProperty.Register(nameof(Sat), typeof(double), typeof(HSBControl),
                new PropertyMetadata(defaultSat, OnColorsChanged, CoerceSat));

        /// <inheritdoc cref="SatProperty"/>
        public double Sat
        {
            get => (double)GetValue(SatProperty);
            set => SetValue(SatProperty, value);
        }

        private static object CoerceSat(DependencyObject dependObj, object value)
        {
            if (value is double val)
            {
                return CoerceHSB(val, Cnst.MaxSat);
            }
            return 0;
        }

        #endregion

        #region brt

        /// <summary>
        /// The HSB brightness property
        /// </summary>
        public static readonly DependencyProperty BrtProperty =
            DependencyProperty.Register(nameof(Brt), typeof(double), typeof(HSBControl),
                new PropertyMetadata(defaultBrt, OnColorsChanged, CoerceBrt));

        /// <inheritdoc cref="BrtProperty"/>
        public double Brt
        {
            get => (double)GetValue(BrtProperty);
            set => SetValue(BrtProperty, value);
        }

        private static object CoerceBrt(DependencyObject dependObj, object value)
        {
            if (value is double val)
            {
                return CoerceHSB(val, Cnst.MaxBrt);
            }
            return 0;
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

        #region hex

        /// <summary>
        /// The hex color property
        /// </summary>
        public static readonly DependencyProperty HexProperty =
            DependencyProperty.Register(nameof(Hex), typeof(string), typeof(HSBControl),
                new PropertyMetadata(string.Empty, OnHexChanged, CoerceHex));

        /// <inheritdoc cref="HexProperty"/>
        public string Hex
        {
            get => (string)GetValue(HexProperty);
            set => SetValue(HexProperty, value);
        }

        private static object CoerceHex(DependencyObject dependObj, object value)
        {
            if (value is string hex)
            {
                return hex.ToUpper();
            }
            return string.Empty;
        }

        private static void OnHexChanged(DependencyObject dependObj, DependencyPropertyChangedEventArgs evArgs)
        {
            if (dependObj is HSBControl con)
            {
                con.OnHexChanged();
            }
        }

        /// <summary>
        /// Method to invoke upon changing Hex value
        /// </summary>
        protected virtual void OnHexChanged()
        {
            if (!ChangingVal)
            {
                ChangingVal = true;
                try
                {
                    Brush = new BrushConverter().ConvertFromString(Hex) as SolidColorBrush;
                    var color = Brush.Color;
                    (Hue, Sat, Brt) = ColorCodeHelper.RgbToHsb(color.R, color.G, color.B);
                }
                catch (System.FormatException)
                { }
                finally
                {
                    ChangingVal = false;
                }
            }
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
            if (!ChangingVal)
            {
                ChangingVal = true;
                try
                {
                    Brush = (Hue, Sat, Brt).HsbToRgb().ToBrush();
                    Hex = $"#{Brush.Color.R:X2}{Brush.Color.G:X2}{Brush.Color.B:X2}";
                }
                finally
                {
                    ChangingVal = false;
                }
            }
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
    }
}
