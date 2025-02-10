﻿using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls
{
    /// <summary>
    /// A HSB hue slider
    /// </summary>
    public partial class HueSlider : HSBSlider
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HueSlider() : base()
        {
            InitializeComponent();
            SetImage();
        }

        /// <inheritdoc cref="HSBSlider.BindXtoHSB"/>
        protected override void BindXtoHSB()
        {
            base.BindXtoHSB();
            BindX.ConverterParameter = new double[] { Width, Cnst.MaxHue};
            SetBinding(HueProperty, BindX);
        }

        protected override void HSBControl_MouseMove(object sender, MouseEventArgs e)
        {
            base.HSBControl_MouseMove(sender, e);
            if (IsMouseCaptured)
            {
                var a = Hue;
                var b = X;
            }
        }

        private void SetImage()
        {
            RectLayer1.Fill = new ImageBrush()
            {
                ImageSource = (BitmapImage)Resources["HueStickPNG"]
            };
        }
    }
}
