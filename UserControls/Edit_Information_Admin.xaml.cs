using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for Edit_Information_Admin.xaml
    /// </summary>
    public partial class Edit_Information_Admin : UserControl
    {
        public Edit_Information_Admin()
        {
            InitializeComponent();
        }

        private List<UserEntity> user;

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Add_User();
            window.ShowDialog();

            user = new UserDAO().getAll(typeof(UserEntity)) as List<UserEntity>;
            listUser.ItemsSource = user;
            listUser.SelectedIndex = 0;

            CollectionView view = CollectionViewSource.GetDefaultView(listUser.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            BaseDAO dao = new UserDAO();
            UserEntity temp = listUser.SelectedItem as UserEntity;

            if (temp == null)
            {
                return;
            }

            int idx = listUser.SelectedIndex + 1;
            if (idx == listUser.Items.Count)
            {
                idx = 0;
            }

            listUser.SelectedIndex = idx;

            dao.delete(temp);

            user = dao.getAll(typeof(UserEntity)) as List<UserEntity>;

            listUser.ItemsSource = user;

            CollectionView view = CollectionViewSource.GetDefaultView(listUser.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            UserEntity temp = listUser.SelectedItem as UserEntity;

            if (temp == null)
            {
                return;
            }

            new UserDAO().update(temp);
        }

        private bool CustomFilter(object obj)
        {
            if (string.IsNullOrEmpty(search_text_box.Text))
            {
                return true;
            }

            UserEntity temp = obj as UserEntity;
            return (temp.FullName.IndexOf(search_text_box.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    temp.Username.IndexOf(search_text_box.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    temp.Role.ToString().IndexOf(search_text_box.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    temp.UserID.ToString().IndexOf(search_text_box.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    temp.IDCardNumber.IndexOf(search_text_box.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    temp.Address.IndexOf(search_text_box.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    temp.Birthdate.ToShortDateString().IndexOf(search_text_box.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BaseDAO dao = new UserDAO();
            user = dao.getAll(typeof(UserEntity)) as List<UserEntity>;
            listUser.ItemsSource = user;
            listUser.SelectedIndex = 0;
            CollectionView view = CollectionViewSource.GetDefaultView(listUser.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
        }

        private void search_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listUser.ItemsSource).Refresh();
        }
    }
}