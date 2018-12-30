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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for Edit_User_Page.xaml
    /// </summary>
    public partial class Edit_User_Page : Page
    {

        public Edit_User_Page()
        {
            InitializeComponent();
        }
        List<UserEntity> user;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BaseDAO dao = BaseDAO.getInstance();
            user = dao.getAll(typeof(UserEntity)) as List<UserEntity>;
            listUser.ItemsSource = user;
            listUser.SelectedIndex = 0;
            CollectionView view = CollectionViewSource.GetDefaultView(listUser.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserEntity temp = listUser.SelectedItem as UserEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Name.Text.ToString().ToLower(), temp.Username.ToLower()))
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = true;
            }
            else
            {
                btn_Delete.IsEnabled = true;
                btn_Update.IsEnabled = true;
            }
        }

        private void txt_Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserEntity temp = listUser.SelectedItem as UserEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Password.Text.ToString().ToLower(), temp.Password.ToLower()))
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = true;
            }
            else
            {
                btn_Delete.IsEnabled = true;
                btn_Update.IsEnabled = true;
            }
        }

        private void txt_Role_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserEntity temp = listUser.SelectedItem as UserEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Role.Text.ToString().ToLower(), temp.Role))
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = true;
            }
            else
            {
                btn_Delete.IsEnabled = true;
                btn_Update.IsEnabled = true;
            }
        }

        private void txt_FullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserEntity temp = listUser.SelectedItem as UserEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_FullName.Text.ToString().ToLower(), temp.FullName.ToLower()))
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = true;
            }
            else
            {
                btn_Delete.IsEnabled = true;
                btn_Update.IsEnabled = true;
            }
        }

        private void txt_Birthdate_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserEntity temp = listUser.SelectedItem as UserEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Birthdate.Text.ToString().ToLower(), temp.Birthdate))
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = true;
            }
            else
            {
                btn_Delete.IsEnabled = true;
                btn_Update.IsEnabled = true;
            }
        }


        private void txt_IDCardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserEntity temp = listUser.SelectedItem as UserEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_IDCardNumber.Text.ToString().ToLower(), temp.IDCardNumber.ToLower()))
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = true;
            }
            else
            {
                btn_Delete.IsEnabled = true;
                btn_Update.IsEnabled = true;
            }
        }


        private void txt_Address_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserEntity temp = listUser.SelectedItem as UserEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Address.Text.ToString().ToLower(), temp.Address.ToLower()))
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = true;
            }
            else
            {
                btn_Delete.IsEnabled = true;
                btn_Update.IsEnabled = true;
            }
        }

       

       

        private void search_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txtOrig = search_text_box.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();
            CollectionViewSource.GetDefaultView(listUser.ItemsSource).Refresh();
            
        }
        



        

        private bool CustomFilter(object obj)
        {
            if (string.IsNullOrEmpty(search_text_box.Text))
            {
                return true;
            }
            else
            {
                UserEntity temp = obj as UserEntity;
                return (temp.FullName.IndexOf(search_text_box.Text, StringComparison.OrdinalIgnoreCase) >= 0);   
            }

        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            UserEntity temp = listUser.SelectedItem as UserEntity;
            BaseDAO dao = BaseDAO.getInstance();
            dao.update(temp);
            btn_Delete.IsEnabled = true;
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            BaseDAO dao = BaseDAO.getInstance();
            UserEntity temp = listUser.SelectedItem as UserEntity;
            int idx = listUser.SelectedIndex + 1;
            if (idx == listUser.Items.Count) idx = 0;
            listUser.SelectedIndex = idx;
            dao.delete(temp);
            user = dao.getAll(typeof(UserEntity)) as List<UserEntity>;
            listUser.ItemsSource = user;
            CollectionView view = CollectionViewSource.GetDefaultView(listUser.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
           
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Add_User();
            window.ShowDialog();
            BaseDAO dao = BaseDAO.getInstance();
            user = dao.getAll(typeof(UserEntity)) as List<UserEntity>;
            listUser.ItemsSource = user;
            listUser.SelectedIndex = 0;
            CollectionView view = CollectionViewSource.GetDefaultView(listUser.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
        }
    }

   
}
