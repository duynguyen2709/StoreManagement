using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for Edit_Product_Page.xaml
    /// </summary>
    public partial class Edit_Product_Page : Page
    {
        public Edit_Product_Page()
        {
            InitializeComponent();
        }

        private List<ProductEntity> products;

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Add_Product_Popup();
            window.ShowDialog();
            BaseDAO dao = BaseDAO.getInstance();
            products = dao.getAll(typeof(ProductEntity)) as List<ProductEntity>;
            listBox.ItemsSource = products;
            listBox.SelectedIndex = 0;
            CollectionView view = CollectionViewSource.GetDefaultView(listBox.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            BaseDAO dao = BaseDAO.getInstance();
            ProductEntity temp = listBox.SelectedItem as ProductEntity;
            int idx = listBox.SelectedIndex + 1;
            if (idx == listBox.Items.Count) idx = 0;
            listBox.SelectedIndex = idx;
            dao.delete(temp);
            products = dao.getAll(typeof(ProductEntity)) as List<ProductEntity>;
            listBox.ItemsSource = products;
            CollectionView view = CollectionViewSource.GetDefaultView(listBox.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            ProductEntity temp = listBox.SelectedItem as ProductEntity;
            BaseDAO dao = BaseDAO.getInstance();
            dao.update(temp);
            btn_Delete.IsEnabled = true;
        }

        private bool CustomFilter(object obj)
        {
            if (string.IsNullOrEmpty(search_text_box.Text.Trim()))
            {
                return true;
            }
            else
            {
                ProductEntity temp = obj as ProductEntity;
                return (temp.ProductName.IndexOf(search_text_box.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0
                        || temp.ProductID.ToString().IndexOf(search_text_box.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0
                        || temp.Brand.IndexOf(search_text_box.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0
                        || temp.Type.ToString().IndexOf(search_text_box.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BaseDAO dao = BaseDAO.getInstance();
            products = dao.getAll(typeof(ProductEntity)) as List<ProductEntity>;
            listBox.ItemsSource = products;
            listBox.SelectedIndex = 0;
            CollectionView view = CollectionViewSource.GetDefaultView(listBox.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
        }

        private void search_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            // string txtOrig = search_text_box.Text.Trim(); string upper = txtOrig.ToUpper(); string
            // lower = txtOrig.ToLower();
            CollectionViewSource.GetDefaultView(listBox.ItemsSource).Refresh();

            //listBox.SelectedIndex = 0;
        }

        private void txt_Brand_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductEntity temp = listBox.SelectedItem as ProductEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Brand.Text.ToString().ToLower(), temp.Brand.ToLower()))
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

        private void txt_Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductEntity temp = listBox.SelectedItem as ProductEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Description.Text.ToString().ToLower(), temp.Description.ToLower()))
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

        private void txt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductEntity temp = listBox.SelectedItem as ProductEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Name.Text.ToString().ToLower(), temp.ProductName.ToLower()))
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

        private void txt_Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductEntity temp = listBox.SelectedItem as ProductEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Price.Text.ToString().ToLower(), temp.Price.ToString().ToLower()))
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

        private void txt_Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductEntity temp = listBox.SelectedItem as ProductEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Quantity.Text.ToString().ToLower(), temp.Quantity.ToString().ToLower()))
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

        private void txt_Type_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductEntity temp = listBox.SelectedItem as ProductEntity;
            if (temp == null)
            {
                btn_Delete.IsEnabled = false;
                btn_Update.IsEnabled = false;
            }
            else if (!String.Equals(txt_Type.Text.ToString().ToLower(), temp.Type.ToLower()))
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
    }
}