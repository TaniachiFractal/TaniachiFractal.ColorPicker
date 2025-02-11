using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls
{
    /// <summary>
    /// A slider that sets one of the HSB values
    /// </summary>
    public class HSBSlider : HSBColorSetter
    {
        private const byte width = 255, height = 10, sliderSize = 20;
        private const double margin = 0.8;

        /// <summary>
        /// The first rectangle
        /// </summary>
        protected Border RectLayer1 = new Border()
        {
            Width = width - margin,
            Height = height - margin,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
        };
        /// <summary>
        /// The second rectangle
        /// </summary>
        protected Border RectLayer2 = new Border()
        {
            Width = width,
            Height = height,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        /// <summary>
        /// The third rectangle
        /// </summary>
        protected Border RectLayer3 = new Border()
        {
            Width = width + margin,
            Height = height + margin,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
        };

        /// <summary>
        /// Constructor
        /// </summary>
        public HSBSlider() : base()
        {
            Width = width;
            Height = height;
            Background = Colors.Cyan.ToBrush();
        }

        /// <summary>
        /// Load children
        /// </summary>
        protected override void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            base.HSBControl_Loaded(sender, e);

            SliderCircle.Width = SliderCircle.Height = sliderSize;

            RectLayer1.CornerRadius = new CornerRadius(CornerRadius - 1);
            RectLayer2.CornerRadius = new CornerRadius(CornerRadius);
            RectLayer3.CornerRadius = new CornerRadius(CornerRadius + 1);

            RootControl.Children.Add(RectLayer1);
            RootControl.Children.Add(RectLayer2);
            RootControl.Children.Add(RectLayer3);

            RectLayer3.BorderBrush = Colors.DimGray.ToBrush();
            RectLayer3.BorderThickness = new Thickness(2);

            InitSliderCircle();

            Y -= ActualHeight / 2;

            Background = Colors.Transparent.ToBrush();
        }

        /// <inheritdoc cref="HSBColorSetter.UpdXY(double, double)"/>
        protected override void UpdXY(double x, double y)
        {
            base.UpdXY(x, y);
            X = x;
        }

    }
}
