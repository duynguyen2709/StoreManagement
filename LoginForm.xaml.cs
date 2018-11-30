using StoreManagement.Entities;
using System.Windows;
using StoreManagement.DAO;

namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            int role = validateAccount(username, password);

            switch (role)
            {
                case 0:
                    var managerDashboard = new ManagerDashboard();
                    managerDashboard.Show();
                    this.Close();
                    break;

                case 1:

                    break;

                case 2:

                    break;

                default:
                    lblLoginError.Visibility = Visibility.Visible;
                    break;
            }
        }

        private int validateAccount(string username, string password)
        {
            if (username.Length == 0 || password.Length == 0)
                return -1;

            using (var context = new StoreManagementEntities())
            {
                foreach (var user in context.Users)
                {
                    if (user.Username == username && user.Password == password)
                        return user.Role;
                }
            }

            return -1;
        }
    }
}