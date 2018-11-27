using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
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
            BASE_STATE = this.WindowState;

            User user = new User();
            user.Username = "newuser";
            user.Password = "123";
            user.FullName = "asdad saf";
            user.Role = 1;
            user.Address = "asdiaf asd";
            user.Birthdate = DateTime.Now;
            user.IDCardNumber = "123213213";

            BaseDAO dao = BaseDAO.getInstance();
            dao.insert(user);
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

            switch (index)
            {
                case 0:
                    break;

                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

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