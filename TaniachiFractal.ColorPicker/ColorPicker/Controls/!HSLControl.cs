using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// A control with HSL Hue, Saturation and Lightness properties.
    /// </summary>
    public partial class HSLControl : UserControl, INotifyPropertyChanged
    {
        #region hue

        /// <summary>
        /// The HSL hue property
        /// </summary>
        public static readonly DependencyProperty HueProperty =
            DependencyProperty.Register(nameof(Hue), typeof(byte), typeof(SaturationLightnessSquare),
                new PropertyMetadata((byte)0, OnColorsChanged));

        /// <inheritdoc cref="HueProperty"/>
        public byte Hue
        {
            get => (byte)GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }

        #endregion

        #region saturation

        /// <summary>
        /// The HSL saturation property
        /// </summary>
        public static readonly DependencyProperty SaturationProperty =
            DependencyProperty.Register(nameof(Saturation), typeof(byte), typeof(SaturationLightnessSquare),
                new PropertyMetadata((byte)0, OnColorsChanged));

        /// <inheritdoc cref="SaturationProperty"/>
        public byte Saturation
        {
            get => (byte)GetValue(SaturationProperty);
            set => SetValue(SaturationProperty, value);
        }

        #endregion

        #region lightness

        /// <summary>
        /// The HSL lightness property
        /// </summary>
        public static readonly DependencyProperty LightnessProperty =
            DependencyProperty.Register(nameof(Lightness), typeof(byte), typeof(SaturationLightnessSquare),
                new PropertyMetadata((byte)0, OnColorsChanged));

        /// <inheritdoc cref="LightnessProperty"/>
        public byte Lightness
        {
            get => (byte)GetValue(LightnessProperty);
            set => SetValue(LightnessProperty, value);
        }

        #endregion

        #region brush

        /// <summary>
        /// The SolidColorBrush/Color/Fill property
        /// </summary>
        public static readonly DependencyProperty BrushProperty =
            DependencyProperty.Register(nameof(Brush), typeof(SolidColorBrush), typeof(SaturationLightnessSquare),
                new PropertyMetadata(new SolidColorBrush(Colors.White), OnBrushChanged));

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
            if (dependObj is HSLControl con)
            {
                con.OnColorsChanged();
            }
        }

        /// <summary>
        /// Method to invoke upon changing HSL values
        /// </summary>
        protected virtual void OnColorsChanged()
        {
            Brush = ColorCodeConverter.HSLToRGB(Hue, Saturation, Lightness).ToBrush();
        }

        #endregion

        #region on brush changed

        private static void OnBrushChanged(DependencyObject dependObj, DependencyPropertyChangedEventArgs evArgs)
        {
            if (dependObj is HSLControl con)
            {
                con.OnBrushChanged();
            }
        }

        /// <summary>
        /// Method to invoke upon changing the Brush
        /// </summary>
        protected virtual void OnBrushChanged()
        {}

        #endregion

        /// <inheritdoc cref="PropertyChangedEventHandler"/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invoke <see cref="PropertyChanged"/>
        /// </summary>
        protected void PropertyHasChanged()
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
