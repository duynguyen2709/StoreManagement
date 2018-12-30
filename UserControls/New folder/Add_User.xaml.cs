using StoreManagement.DAO;
using StoreManagement.Entities;
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
using System.Windows.Shapes;

namespace StoreManagement
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

    

        private void txt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_Name.Text.ToString().Trim().ToLower(), ""))
            {
                btn_Add.IsEnabled = false;
            }
            else
            {
                btn_Add.IsEnabled = true;
            }
        }
        private void txt_Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_Password.Text.ToString().Trim().ToLower(), ""))
            {
                btn_Add.IsEnabled = false;
            }
            else
            {
                btn_Add.IsEnabled = true;
            }
        }
        private void txt_Role_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_Role.Text.ToString().Trim().ToLower(), ""))
            {
                btn_Add.IsEnabled = false;
            }
            else
            {
                btn_Add.IsEnabled = true;
            }
        }

        private void txt_FullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_FullName.Text.ToString().Trim().ToLower(), ""))
            {
                btn_Add.IsEnabled = false;
            }
            else
            {
                btn_Add.IsEnabled = true;
            }
        }

        //private void txt_Birthdate_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (String.Equals(txt_Birthdate.Text.ToString().Trim().ToLower(), ""))
        //    {
        //        btn_Add.IsEnabled = false;
        //    }
        //    else
        //    {
        //        btn_Add.IsEnabled = true;
        //    }
        //}

       
        private void txt_IdCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_IdCard.Text.ToString().Trim().ToLower(), ""))
            {
                btn_Add.IsEnabled = false;
            }
            else
            {
                btn_Add.IsEnabled = true;
            }
        }

        private void txt_Address_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_Address.Text.ToString().Trim().ToLower(), ""))
            {
                btn_Add.IsEnabled = false;
            }
            else
            {
                btn_Add.IsEnabled = true;
            }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

           
                UserEntity newUser = new UserEntity();
                newUser.Username = txt_Name.Text;
            newUser.Password = txt_Password.Text;
            newUser.Role = int.Parse(txt_Role.Text);
            newUser.FullName = txt_FullName.Text;
            newUser.Birthdate = DateTime.Parse(txt_Birthdate.Text);
            newUser.IDCardNumber =txt_IdCard.Text;
            newUser.Address = txt_Address.Text;
                BaseDAO dao = BaseDAO.getInstance();
                dao.insert(newUser);
                this.Close();
            
        }
    }
}
