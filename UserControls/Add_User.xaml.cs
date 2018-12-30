using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for Add_User.xaml
    /// </summary>
    public partial class Add_User : Window
    {
        public Add_User()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            UserEntity newUser = new UserEntity
            {
                Username = txt_Name.Text,
                Password = txt_Password.Password,
                Role = int.Parse(txt_Role.Text),
                FullName = txt_FullName.Text,
                Birthdate = DateTime.Parse(txt_Birthdate.Text),
                IDCardNumber = txt_IdCard.Text,
                Address = txt_Address.Text
            };
            int id = new UserDAO().insert(newUser);

            if (id <= 0)
            {
                MessageBox.Show("Error Adding New User", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Add new User success",
                                "Information",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }

            Close();
        }

        private void enableButtonAdd(TextBox textBox)
        {
            btn_Add.IsEnabled = !string.Equals(textBox.Text.Trim().ToLower(), "");
        }

        private void txt_Address_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonAdd(txt_Address);
        }

        private void txt_FullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonAdd(txt_FullName);
        }

        private void txt_IdCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonAdd(txt_IdCard);
        }

        private void txt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonAdd(txt_Name);
        }

        private void Txt_Password_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            btn_Add.IsEnabled = !string.Equals(txt_Password.Password.Trim().ToLower(), "");
        }

        private void txt_Role_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonAdd(txt_Role);
        }
    }
}