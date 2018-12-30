using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for Edit_Information.xaml
    /// </summary>
    public partial class Edit_Information : UserControl
    {
        public Edit_Information()
        {
            InitializeComponent();
        }

        private UserEntity user;

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            UserDAO dao = new UserDAO();

            try
            {
                user.Username = txt_Name.Text;
                user.Password = txt_Password.Password;
                user.Role = (txt_Role.Text == "Cashier" ? 1 : 2);
                user.FullName = txt_FullName.Text;
                user.Birthdate = DateTime.Parse(txt_Birthdate.Text);
                user.IDCardNumber = txt_IdCard.Text;
                user.Address = txt_Address.Text;

                dao.update(user);

                MessageBox.Show("Edit info success", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Edit info failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            user = LoginForm.currentUser;

            txt_Name.Text = user.Username;
            txt_Password.Password = user.Password;
            txt_Role.Text = (user.Role == 1 ? "Cashier" : "StorageManager");
            txt_FullName.Text = user.FullName;
            txt_Birthdate.Text = user.Birthdate.ToShortDateString();
            txt_IdCard.Text = user.IDCardNumber;
            txt_Address.Text = user.Address;
        }
    }
}