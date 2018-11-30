using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
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

            BaseDAO dao = BaseDAO.getInstance();

            UserEntity entity = new UserEntity()
            {
                Address = "asd",
                Birthdate = DateTime.Today,
                FullName = "test get id",
                IDCardNumber = "12345",
                Password = "123",
                Role = 0,
                Username = "testgetid"
            };

            int id = dao.insert(entity);
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