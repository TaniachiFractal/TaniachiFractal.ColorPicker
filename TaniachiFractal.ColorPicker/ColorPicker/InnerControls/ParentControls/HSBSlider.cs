using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;
using TaniachiFractal.ColorPicker.ColorPicker.ValueConverters;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls
{
    /// <summary>
    /// A slider that sets one of the HSB values
    /// </summary>
    public class HSBSlider : HSBColorSetter
    {
        private const byte width = 255, height = 10;

        /// <summary>
        /// The first rectangle
        /// </summary>
        protected Rectangle RectLayer1 = new Rectangle() { Width = width, Height = height };
        /// <summary>
        /// The second rectangle
        /// </summary>
        protected Rectangle RectLayer2 = new Rectangle() { Width = width, Height = height };
        /// <summary>
        /// The third rectangle
        /// </summary>
        protected Rectangle RectLayer3 = new Rectangle() { Width = width, Height = height };

        /// <summary>
        /// <see cref="Binding"/> to <see cref="HSBColorSetter.X"/><br/>
        /// ConverterParameter: <see cref="double"/>[] 0: Slider width, 1: Max value
        /// </summary>
        protected Binding BindX;

        /// <summary>
        /// Constructor
        /// </summary>
        public HSBSlider() : base()
        {
            Width = width;
            Height = height;
            Background = Colors.Cyan.NewSolidColorBrush();

            BindX = new Binding(nameof(X))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Converter = new SliderToValueConverter()
            };
        }

        /// <summary>
        /// Load children
        /// </summary>
        protected override void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            base.HSBControl_Loaded(sender, e);

            SliderCircle.Width = SliderCircle.Height = 20;

            RectLayer1.RadiusX = RectLayer2.RadiusX = RectLayer3.RadiusX = CornerRadius;
            RectLayer1.RadiusY = RectLayer2.RadiusY = RectLayer3.RadiusY = CornerRadius;

            RootControl.Children.Add(RectLayer1);
            RootControl.Children.Add(RectLayer2);
            RootControl.Children.Add(RectLayer3);

            InitSliderCircle();

            Y -= ActualHeight / 2;

            BindXtoHSB();

            Background = Colors.Transparent.NewSolidColorBrush();
        }

        /// <inheritdoc cref="HSBColorSetter.UpdXY(double, double)"/>
        protected override void UpdXY(double x, double y)
        {
            base.UpdXY(x, y);
            X = x;
        }

        /// <summary>
        /// Bind the X value to the needed one of the HSB values
        /// </summary>
        protected virtual void BindXtoHSB()
        {
        }

    }
}
