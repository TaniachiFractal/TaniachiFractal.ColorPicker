namespace TaniachiFractal.ColorPicker.ColorPicker.Controls
{
    /// <summary>
    /// A small circle with HSL properties and a contrasting rim
    /// </summary>
    public partial class HSLCircle : HSLControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HSLCircle()
        {
            InitializeComponent();
        }

        private void HSLControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ColorCircle.StrokeThickness = ActualHeight / 10;
        }
    }
}
