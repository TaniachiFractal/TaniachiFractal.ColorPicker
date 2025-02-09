using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls
{
    /// <summary>
    /// A control with Hue, Saturation and Brightness properties
    /// </summary>
    internal class HSBControl : UserControl
    {
        #region hue

        /// <summary>
        /// The HSB hue property
        /// </summary>
        public static readonly DependencyProperty HueProperty =
            DependencyProperty.Register(nameof(Hue), typeof(float), typeof(HSBControl),
                new PropertyMetadata(0f, OnColorsChanged));

        /// <inheritdoc cref="HueProperty"/>
        public float Hue
        {
            get => (float)GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }

        #endregion

        #region saturation

        /// <summary>
        /// The HSB sat property
        /// </summary>
        public static readonly DependencyProperty SaturationProperty =
            DependencyProperty.Register(nameof(Saturation), typeof(float), typeof(HSBControl),
                new PropertyMetadata(0f, OnColorsChanged));

        /// <inheritdoc cref="SaturationProperty"/>
        public float Saturation
        {
            get => (float)GetValue(SaturationProperty);
            set => SetValue(SaturationProperty, value);
        }

        #endregion

        #region brightness

        /// <summary>
        /// The HSB brt property
        /// </summary>
        public static readonly DependencyProperty BrightnessProperty =
            DependencyProperty.Register(nameof(Brightness), typeof(float), typeof(HSBControl),
                new PropertyMetadata(0f, OnColorsChanged));

        /// <inheritdoc cref="BrightnessProperty"/>
        public float Brightness
        {
            get => (float)GetValue(BrightnessProperty);
            set => SetValue(BrightnessProperty, value);
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
            Brush = ColorCodeHelper.HsbToRgb(Hue, Saturation, Brightness).ToBrush();
        }

        #endregion
    }
}
