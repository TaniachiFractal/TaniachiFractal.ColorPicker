using System.Linq.Expressions;
using System.Windows.Data;
using TaniachiFractal.ColorPicker.ColorPicker.ColorStructs;
using TaniachiFractal.ColorPicker.ColorPicker.InnerControls.ParentControls;

namespace TaniachiFractal.ColorPicker.ColorPicker
{
    /// <summary>
    /// HSB color picker
    /// </summary>
    public partial class ColorPicker : HSBControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ColorPicker()
        {
            InitializeComponent();

            DataContext = this;

            BindChildren();

            OldColor.HSB = HSB;
        }

        private void BindChildren()
        {
            var bind = new Binding(nameof(HSB))
            {
                Source = this,
                Mode = BindingMode.TwoWay,
            };

            ShowColor.SetBinding(HSBProperty, bind);
        }
    }
}
