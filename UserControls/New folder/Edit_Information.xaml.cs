using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StoreManagement.DAO;
using StoreManagement.Entities;


namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for Edit_Information.xaml
    /// </summary>
    public partial class Edit_Information : Page
    {
        LoginForm Form = Application.Current.Windows[0] as LoginForm;
        public Edit_Information()
        {
            InitializeComponent();
        }
        UserEntity user;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string username = Form.txtUsername.Text;
            string password = Form.txtPassword.Password;
            BaseDAO dao = BaseDAO.getInstance();
            user = dao.get(takeID(username, password), typeof(UserEntity)) as UserEntity;
            txt_Name.Text = user.Username;
            txt_Password.Text = user.Password;
            txt_Role.Text = user.Role.ToString();
            txt_FullName.Text = user.FullName;
            txt_Birthdate.Text = user.Birthdate.ToString();
            txt_IdCard.Text = user.IDCardNumber;
            txt_Address.Text = user.Address;

        }
            
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            
            BaseDAO dao = BaseDAO.getInstance();
            user.Username = txt_Name.Text;
            user.Password = txt_Password.Text;
            user.Role = int.Parse(txt_Role.Text);
            user.FullName = txt_FullName.Text;
            user.Birthdate = DateTime.Parse(txt_Birthdate.Text);
            user.IDCardNumber = txt_IdCard.Text;
            user.Address = txt_Address.Text;
            dao.update(user);
            btn_Edit.IsEnabled = false;
            MessageBox.Show("Chỉnh sửa thành công","Thông báo");
        }

        private int takeID(string username, string password)
        {
            if (username.Length == 0 || password.Length == 0)
                return -1;

            using (var context = new StoreManagementEntities())
            {
                foreach (var user in context.Users)
                {
                    if (user.Username == username && user.Password == password)
                        return user.UserID;
                }
            }

            return -1;
        }


        private void txt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_Name.Text.ToString().Trim().ToLower(), user.Username.ToLower()))
            {
                btn_Edit.IsEnabled = false;
            }
            else
            {
                btn_Edit.IsEnabled = true;
            }
        }
        private void txt_Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_Password.Text.ToString().Trim().ToLower(), user.Password.ToLower()))
            {
                btn_Edit.IsEnabled = false;
            }
            else
            {
                btn_Edit.IsEnabled = true;
            }
        }
        private void txt_Role_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_Role.Text.ToString().Trim().ToLower(), user.Role))
            {
                btn_Edit.IsEnabled = false;
            }
            else
            {
                btn_Edit.IsEnabled = true;
            }
        }

        private void txt_FullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_FullName.Text.ToString().Trim().ToLower(), user.FullName.ToLower()))
            {
                btn_Edit.IsEnabled = false;
            }
            else
            {
                btn_Edit.IsEnabled = true;
            }
        }

        private void txt_Birthdate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_Birthdate.Text.ToString().Trim().ToLower(), user.Birthdate.ToString().ToLower()))
            {
                btn_Edit.IsEnabled = false;
            }
            else
            {
                btn_Edit.IsEnabled = true;
            }
        }


        private void txt_IdCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_IdCard.Text.ToString().Trim().ToLower(), user.IDCardNumber.ToLower()))
            {
                btn_Edit.IsEnabled = false;
            }
            else
            {
                btn_Edit.IsEnabled = true;
            }
        }

        private void txt_Address_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_Address.Text.ToString().Trim().ToLower(), user.Address.ToLower()))
            {
                btn_Edit.IsEnabled = false;
            }
            else
            {
                btn_Edit.IsEnabled = true;
            }
        }
    }
}
