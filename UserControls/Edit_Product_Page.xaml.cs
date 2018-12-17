using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for Edit_Product_Page.xaml
    /// </summary>
    public partial class Edit_Product_Page : UserControl
    {
        public Edit_Product_Page()
        {
            InitializeComponent();
        }

        private BaseDAO dao = new ProductDAO();
        private List<ProductEntity> products;

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Add_Product_Popup();
            window.ShowDialog();

            products = dao.getAll(typeof(ProductEntity)) as List<ProductEntity>;
            listBox.ItemsSource = products;
            listBox.SelectedIndex = 0;
            CollectionView view = CollectionViewSource.GetDefaultView(listBox.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            ProductEntity temp = listBox.SelectedItem as ProductEntity;
            int idx = listBox.SelectedIndex + 1;
            if (idx == listBox.Items.Count) idx = 0;
            listBox.SelectedIndex = idx;
            dao.delete(temp);

            Task.Run(() => MessageBox.Show("Xóa sản phẩm thành công",
                                           "Info",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Information));

            products = dao.getAll(typeof(ProductEntity)) as List<ProductEntity>;
            listBox.ItemsSource = products;
            CollectionView view = CollectionViewSource.GetDefaultView(listBox.ItemsSource) as CollectionView;
            view.Filter = CustomFilter;
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            ProductEntity entity = new ProductEntity();
            entity.Brand = txt_Brand.Text;
            entity.Type = txt_Type.Text;
            entity.ProductName = txt_Name.Text;
            entity.ProductID = int.Parse(txt_Id.Text);
            entity.Quantity = int.Parse(txt_Quantity.Text);
            entity.Price = int.Parse(txt_Price.Text);
            entity.ImageURL = txt_URL.Text;
            entity.Description = txt_Description.Text;
            dao.update(entity);

            int index = products.IndexOf(products.Find(obj => obj.ProductID == entity.ProductID));
            products[index] = entity;
            CollectionViewSource.GetDefaultView(listBox.ItemsSource).Refresh();

            MessageBox.Show("Cập nhật thông tin sản phẩm thành công",
                            "Info",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
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
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                                       {
                                           products =
                                               dao.getAll(typeof(ProductEntity)) as List<ProductEntity>;

                                           listBox.ItemsSource = products;
                                           listBox.SelectedIndex = 0;

                                           CollectionView view =
                                               CollectionViewSource.GetDefaultView(listBox.ItemsSource) as
                                                   CollectionView;

                                           view.Filter = CustomFilter;
                                       });
            });
        }

        private void search_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listBox.ItemsSource).Refresh();
        }
    }
}