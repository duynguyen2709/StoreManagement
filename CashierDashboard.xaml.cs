using System.Windows;
using System.Windows.Controls;
using static System.Windows.Controls.UserControl;

namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CashierDashboard : Window
    {
        public CashierDashboard()
        {
            InitializeComponent();
            BASE_STATE = this.WindowState;

            HideBillElements();
        }

        private readonly WindowState BASE_STATE;

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximize_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = BASE_STATE;
            }
        }

        private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void HideBillElements()
        {
            updatebill.IDCashierColumn.Header = "";
            updatebill.IDCashierColumn.CellTemplate = new DataTemplate(typeof(TextBlock));
            updatebill.IDCashierColumn.Width = 0;

            updatebill.deleteColumn.CellTemplate = new DataTemplate(typeof(Button));
            updatebill.editColumn.CellTemplate = new DataTemplate(typeof(Button));

            updatebill.lblIDCashier.Visibility = Visibility.Hidden;
            updatebill.IDCashier.Visibility = Visibility.Collapsed;
            updatebill.IDCashier.Text = LoginForm.Idcashier.ToString();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            GridCursor.Margin = new Thickness(0, 50 + 60 * index, 0, 0);

            switch (index)
            {
                case 0:

                    break;

                case 1:
                    selling.Visibility = Visibility.Visible;

                    updatebill.Visibility = Visibility.Hidden;
                    break;

                case 2:
                    selling.Visibility = Visibility.Hidden;
                    updatebill.Visibility = Visibility.Visible;
                    break;

                case 3:

                case 4:
                    break;

                case 5:
                    var loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                    break;

                default: break;
            }
        }
    }
}