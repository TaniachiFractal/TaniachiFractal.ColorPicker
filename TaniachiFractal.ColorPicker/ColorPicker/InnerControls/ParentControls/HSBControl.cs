using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaniachiFractal.ColorPicker.ColorPicker.ColorStructs;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls
{
    /// <summary>
    /// A control with Hue, Saturation and Brightness properties
    /// </summary>
    public class HSBControl : UserControl
    {
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

        #region HSB

        /// <summary>
        /// The HSB property
        /// </summary>
        public static readonly DependencyProperty HSBProperty =
            DependencyProperty.Register(nameof(HSB), typeof(HSB), typeof(HSBControl),
                new PropertyMetadata(new HSB(), OnColorsChanged));

        /// <inheritdoc cref="HSBProperty"/>
        public HSB HSB
        {
            get => (HSB)GetValue(HSBProperty);
            set => SetValue(HSBProperty, value);
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
            Brush = HSB.ToRgb().ToBrush();
        }

        #endregion
    }
}
