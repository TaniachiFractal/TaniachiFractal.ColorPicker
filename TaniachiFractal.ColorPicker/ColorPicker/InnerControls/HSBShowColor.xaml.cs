using System.Windows;
using TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls;

namespace TaniachiFractal.ColorPicker.ColorPicker.InnerControls
{
    /// <summary>
    /// A control that shows a HSB color
    /// </summary>
    public partial class HSBShowColor : HSBControl
    {
        #region corner type

        /// <summary>
        /// The <see cref="InnerControls.CornerType"/> property
        /// </summary>
        public static readonly DependencyProperty CornerTypeProperty =
            DependencyProperty.Register(nameof(HSB), typeof(CornerType), typeof(HSBShowColor),
                new PropertyMetadata(CornerType.None));

        /// <inheritdoc cref="CornerTypeProperty"/>
        public CornerType CornerType
        {
            get => (CornerType)GetValue(CornerTypeProperty);
            set => SetValue(CornerTypeProperty, value);
        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public HSBShowColor()
        {
            InitializeComponent();
        }

        private void HSBControl_Loaded(object sender, RoutedEventArgs e)
        {
            switch (CornerType)
            {
                case CornerType.Round:
                    {
                        RectBorder.CornerRadius = new CornerRadius(CornerRadius);
                        break;
                    }
                case CornerType.Rectangle:
                    {
                        RectBorder.CornerRadius = new CornerRadius();
                        break;
                    }
                case CornerType.BowlOnLeft:
                    {
                        RectBorder.CornerRadius = new CornerRadius(CornerRadius, 0, 0, CornerRadius);
                        break;
                    }
                case CornerType.BowlOnRight:
                    {
                        RectBorder.CornerRadius = new CornerRadius(0, CornerRadius, CornerRadius, 0);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }

    /// <summary>
    /// The variations of the <see cref="HSBShowColor"/> corners
    /// </summary>
    public enum CornerType
    {
        /// <summary>
        /// The default value
        /// </summary>
        None,

        /// <summary>
        /// All round corners
        /// </summary>
        Round,

        /// <summary>
        /// No round corners
        /// </summary>
        Rectangle,

        /// <summary>
        /// Round corners on the left side
        /// </summary>
        BowlOnLeft,

        /// <summary>
        /// Round corners on the right side
        /// </summary>
        BowlOnRight
    }
}
