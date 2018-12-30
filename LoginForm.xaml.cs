using StoreManagement.DAO;
using System.Windows;

namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        //lay iduser
        static public int Idcashier;

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
                    ManagerDashboard managerDashboard = new ManagerDashboard();
                    managerDashboard.Show();
                    Close();
                    break;

                case 1:
                    CashierDashboard cashierDashboard = new CashierDashboard();
                    cashierDashboard.Show();
                    Close();
                    break;

                case 2:
                    StorageManagerDashboard storageManagerDashboard = new StorageManagerDashboard();
                    storageManagerDashboard.Show();
                    Close();
                    break;

                default:
                    lblLoginError.Visibility = Visibility.Visible;
                    break;
            }
        }

        private int validateAccount(string username, string password)
        {
            if (username.Length == 0 || password.Length == 0)
            {
                return -1;
            }

            using (StoreManagementEntities context = new StoreManagementEntities())
            {
                foreach (User user in context.Users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        //lay iduser
                        Idcashier = user.UserID;
                        return user.Role;
                    }
                }
            }

            return -1;
        }
    }
}