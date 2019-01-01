using System.Windows.Controls;

namespace StoreManagement.UserControls.Charts
{
    /// <summary>
    /// Interaction logic for ChartsLayout.xaml
    /// </summary>
    public partial class ChartsLayout : UserControl
    {
        public ChartsLayout()
        {
            InitializeComponent();

            cbbLineChart.SelectedIndex = 1;
            cbbBarChart.SelectedIndex = 1;
            cbbPieChart.SelectedIndex = 1;
        }
    }
}