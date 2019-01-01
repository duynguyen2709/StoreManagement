using System.Windows;
using System.Windows.Controls;

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

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*   int index = ListViewMenu.SelectedIndex;

               GridCursor.Margin = new Thickness(0, 50 + 60 * index, 0, 0);

               chart.Visibility = Visibility.Hidden;
               selling.Visibility = Visibility.Hidden;
               editProduct.Visibility = Visibility.Hidden;
               editInformationAdmin.Visibility = Visibility.Hidden;
               updatebill.Visibility = Visibility.Hidden;
               manageShift.Visibility = Visibility.Hidden;

               switch (index)
               {
                   case 0:
                       chart.Visibility = Visibility.Visible;
                       break;

                   case 1:
                       selling.Visibility = Visibility.Visible;
                       break;

                   case 2:
                       editProduct.Visibility = Visibility.Visible;
                       break;

                   case 3:
                       editInformationAdmin.Visibility = Visibility.Visible;
                       break;

                   case 4:
                       updatebill.Visibility = Visibility.Visible;
                       break;

                   case 5:
                       manageShift.Visibility = Visibility.Visible;
                       break;

                   case 6:
                       sale.baskets.Clear();
                       LoginForm loginForm = new LoginForm();
                       loginForm.Show();
                       Close();
                       break;

                   default: break;
               }*/
        }
    }
}