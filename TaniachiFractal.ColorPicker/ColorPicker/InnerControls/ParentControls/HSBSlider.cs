using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using TaniachiFractal.ColorPicker.ColorPicker.Helpers;

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
        protected Rectangle RectLayer1 = new Rectangle() { Width = width, Height = height, Fill = Colors.Violet.NewSolidColorBrush() };

        /// <summary>
        /// The second rectangle
        /// </summary>
        protected Rectangle RectLayer2 = new Rectangle() { Width = width, Height = height };

        /// <summary>
        /// The third rectangle
        /// </summary>
        protected Rectangle RectLayer3 = new Rectangle() { Width = width, Height = height };

        /// <summary>
        /// Constructor
        /// </summary>
        public HSBSlider()
        {
            Width = width;
            Height = height;
            Background = Colors.Cyan.NewSolidColorBrush();
        }

        /// <summary>
        /// Load children
        /// </summary>
        public override void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            SliderCircle.Width = SliderCircle.Height = 20;

            RectLayer1.RadiusX = RectLayer2.RadiusX = RectLayer3.RadiusX = CornerRadius;
            RectLayer1.RadiusY = RectLayer2.RadiusY = RectLayer3.RadiusY = CornerRadius;

            RootGrid.Children.Add(RectLayer1);
            RootGrid.Children.Add(RectLayer2);
            RootGrid.Children.Add(RectLayer3);

            base.HSBControl_Loaded(sender, e);

            Background = Colors.Transparent.NewSolidColorBrush();
        }

    }
}
