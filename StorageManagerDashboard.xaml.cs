using System.Windows;
using System.Windows.Controls;

namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StorageManagerDashboard : Window
    {
        public StorageManagerDashboard()
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
            int index = ListViewMenu.SelectedIndex;

            GridCursor.Margin = new Thickness(0, 50 + 60 * index, 0, 0);

            switch (index)
            {
                case 0:
                    break;

                case 1:
                    break;

                case 2:
                    break;

                case 3:

                case 4:
                    break;

                case 5:
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    Close();
                    break;

                default: break;
            }
        }
    }
}