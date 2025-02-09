using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls
{
    /// <summary>
    /// A <see cref="HSBControl"/> that has a slider which can be moved with a mouse to set a color
    /// </summary>
    public class HSBColorSetter : HSBControl
    {
        /// <summary>
        /// The slider circle
        /// </summary>
        protected readonly HSBShowColor SliderCircle = new HSBShowColor()
        {
            CornerType = CornerType.Round,
            CornerRadius = 100
        };

        /// <summary>
        /// The root grid
        /// </summary>
        protected readonly Grid RootGrid = new Grid();

        #region X

        /// <summary>
        /// The slider X property
        /// </summary>
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register(nameof(X), typeof(double), typeof(HSBColorSetter),
                new PropertyMetadata(0.0));

        /// <inheritdoc cref="XProperty"/>
        public double X
        {
            get => (double)GetValue(XProperty);
            protected set => SetValue(XProperty, value);
        }

        #endregion

        #region Y

        /// <summary>
        /// The slider X property
        /// </summary>
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register(nameof(Y), typeof(double), typeof(HSBColorSetter),
                new PropertyMetadata(0.0));

        /// <inheritdoc cref="YProperty"/>
        public double Y
        {
            get => (double)GetValue(YProperty);
            protected set => SetValue(YProperty, value);
        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public HSBColorSetter()
        {
            DataContext = this;
            BindShowColor();
        }

        /// <summary>
        /// Add a canvas with the slider circle
        /// </summary>
        public virtual void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            Content = RootGrid;
            RootGrid.Children.Add(new Canvas() { Children = { SliderCircle } });
        }

        /// <summary>
        /// Capture mouse
        /// </summary>
        public void HSLControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => CaptureMouse();

        /// <summary>
        /// Release mouse capture
        /// </summary>
        public void HSLControl_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => ReleaseMouseCapture();

        /// <summary>
        /// Move the slider with the mouse
        /// </summary>
        public void HSLControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                var position = e.GetPosition(this);
                var x = position.X;
                var y = position.Y;
                UpdXY(x, y);
            }
        }

        /// <summary>
        /// Update <see cref="X"/> and <see cref="Y"/> values
        /// </summary>
        protected virtual void UpdXY(double x, double y) { }

        private void BindShowColor()
        {
            var bindX = new Binding(nameof(X))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
            };

            var bindY = new Binding(nameof(Y))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
            };

            SliderCircle.SetBinding(Canvas.LeftProperty, bindX);
            SliderCircle.SetBinding(Canvas.RightProperty, bindY);
        }

    }
}
