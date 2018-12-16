using System.Windows;
using System.Windows.Controls;
using StoreManagement.UserControls;

namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ManagerDashboard : Window
    {
        public ManagerDashboard()
        {
            InitializeComponent();

            BASE_STATE = this.WindowState;
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

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            GridCursor.Margin = new Thickness(0, 50 + 60 * index, 0, 0);

            selling.Visibility = Visibility.Hidden;
            editProduct.Visibility = Visibility.Hidden;
            updatebill.Visibility = Visibility.Hidden;
            manageShift.Visibility = Visibility.Hidden;

            switch (index)
            {
                case 0:
                    break;

                case 1:
                    selling.Visibility = Visibility.Visible;
                    break;

                case 2:
                    editProduct.Visibility = Visibility.Visible;
                    break;

                case 3:

                    break;

                case 4:
                    updatebill.Visibility = Visibility.Visible;
                    break;

                case 5:
                    manageShift.Visibility = Visibility.Visible;
                    break;

                case 6:
                    sale.baskets.Clear();
                    var loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                    break;

                default: break;
            }
        }
    }
}