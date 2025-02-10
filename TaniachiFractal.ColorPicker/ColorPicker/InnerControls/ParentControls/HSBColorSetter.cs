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
        /// Half the width of <see cref="SliderCircle"/>
        /// </summary>
        protected double SliderCircleHalfWidth;
        /// <summary>
        /// Half the height of <see cref="SliderCircle"/>
        /// </summary>
        protected double SliderCircleHalfHeight;

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
        public HSBColorSetter() : base()
        {
        }

        /// <summary>
        /// Add a canvas with the slider circle to the root control and init its default properties
        /// </summary>
        protected void InitSliderCircle()
        {
            RootControl.Children.Add(new Canvas() { Children = { SliderCircle } });
            BindSliderCircle();
            SliderCircleHalfHeight = SliderCircle.Height / 2;
            SliderCircleHalfWidth = SliderCircle.Width / 2;
        }

        /// <summary>
        /// Capture mouse
        /// </summary>
        protected void HSBControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => CaptureMouse();

        /// <summary>
        /// Release mouse capture
        /// </summary>
        protected void HSBControl_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => ReleaseMouseCapture();

        /// <summary>
        /// Move the slider with the mouse
        /// </summary>
        protected virtual void HSBControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
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

        private void BindSliderCircle()
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
            SliderCircle.SetBinding(Canvas.TopProperty, bindY);
        }

    }
}
