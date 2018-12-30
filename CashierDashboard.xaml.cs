using StoreManagement.UserControls;
using System.Windows;
using System.Windows.Controls;

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

            HideBillElements();

            BASE_STATE = WindowState;
        }

        private readonly WindowState BASE_STATE;

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximize_OnClick(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = BASE_STATE;
            }
        }

        private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void HideBillElements()
        {
            updatebill.IDCashierColumn.Header = "";
            updatebill.IDCashierColumn.CellTemplate = new DataTemplate(typeof(TextBlock));
            updatebill.IDCashierColumn.Width = 0;

            updatebill.deleteColumn.CellTemplate = new DataTemplate(typeof(Button));
            updatebill.editColumn.CellTemplate = new DataTemplate(typeof(Button));

            updatebill.lblIDCashier.Visibility = Visibility.Collapsed;
            updatebill.IDCashier.Visibility = Visibility.Collapsed;
            updatebill.IDCashier.Text = LoginForm.Idcashier.ToString();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            GridCursor.Margin = new Thickness(0, 50 + 60 * index, 0, 0);

            selling.Visibility = Visibility.Hidden;
            updatebill.Visibility = Visibility.Hidden;
            editInformation.Visibility = Visibility.Hidden;
            manageShift.Visibility = Visibility.Hidden;

            switch (index)
            {
                case 0:

                    break;

                case 1:
                    selling.Visibility = Visibility.Visible;
                    break;

                case 2:
                    updatebill.Visibility = Visibility.Visible;
                    break;

                case 3:
                    editInformation.Visibility = Visibility.Visible;
                    break;

                case 4:
                    manageShift.Visibility = Visibility.Visible;
                    break;

                case 5:
                    sale.baskets.Clear();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    Close();
                    break;

                default: break;
            }
        }
    }
}