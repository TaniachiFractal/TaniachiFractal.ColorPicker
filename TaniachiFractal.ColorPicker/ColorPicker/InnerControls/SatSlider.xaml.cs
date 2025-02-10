﻿using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls;
using TaniachiFractal.ColorPicker.ColorPicker.ValueConverters;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls
{
    /// <summary>
    /// A HSB Saturation slider
    /// </summary>
    public partial class SatSlider : HSBSlider
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SatSlider() : base()
        {
            InitializeComponent();
            SetImage();
        }

        /// <summary>
        /// Add bindings
        /// </summary>
        protected override void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            base.HSBControl_Loaded(sender, e);
            BindX();
            BindHueRect();
            BindBrtRect();
        }

        private void BindX()
        {
            var bind = new Binding(nameof(Sat))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Converter = new SliderToValueConverter(),
                ConverterParameter = new double[] { Width, Cnst.MaxSat, SliderCircleHalfWidth }
            };
            SetBinding(XProperty, bind);
        }

        private void BindHueRect()
        {
            var bind = new Binding(nameof(Hue))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Converter = new HueToSWMBConverter(),
            };
            RectLayer1.SetBinding(BackgroundProperty, bind);
        }

        private void BindBrtRect()
        {
            var bind = new Binding(nameof(Brt))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Converter = new BrightnessToAlphaSWMBConverter(),
            };
            RectLayer3.SetBinding(BackgroundProperty, bind);
        }

        private void SetImage()
        {
            RectLayer2.Background = new ImageBrush()
            {
                ImageSource = (BitmapImage)Resources["SatStickPNG"]
            };
        }
    }
}
