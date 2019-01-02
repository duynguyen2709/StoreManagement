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
    /// Interaction logic for Import_Product.xaml
    /// </summary>
    public partial class Import_Product : UserControl
    {
        public Import_Product()
        {
            InitializeComponent();
        }

        private BaseDAO dao = new ProductDAO();
        private List<ProductEntity> products;

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            // ProductEntity entity = new ProductEntity { Brand = txt_Brand.Text, Type =
            // txt_Type.Text, ProductName = txt_Name.Text, ProductID = int.Parse(txt_Id.Text),
            // Quantity = int.Parse(txt_Quantity.Text), Price = int.Parse(txt_Price.Text), ImageURL =
            // txt_URL.Text, Description = txt_Description.Text }; dao.update(entity);
            //
            // int index = products.IndexOf(products.Find(obj => obj.ProductID == entity.ProductID));
            // products[index] = entity;
            int oldQuantity = int.Parse(txt_Quantity.Text);
            int importQuantity = int.Parse(txt_ImportQuantity.Text);

            if (oldQuantity + importQuantity <= 5)
            {
                MessageBox.Show("Cần nhập nhiều hơn mức tồn tối thiểu (5 sản phẩm)",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);

                return;
            }

            GoodsImportEntity entity = new GoodsImportEntity()
            {
                ImportDate = DateTime.Today.Date,
                ProductID = int.Parse(txt_Id.Text),
                Quantity = int.Parse(txt_ImportQuantity.Text)
            };

            GoodsImportDAO importDAO = new GoodsImportDAO();
            importDAO.insert(entity);

            products.RemoveAll(temp => temp.ProductID == int.Parse(txt_Id.Text));
            CollectionViewSource.GetDefaultView(listBox.ItemsSource).Refresh();

            MessageBox.Show("Nhập hàng thành công",
                            "Info",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

            txt_ImportQuantity.Clear();
        }

        private bool CustomFilter(object obj)
        {
            if (string.IsNullOrEmpty(search_text_box.Text.Trim()))
            {
                return true;
            }

            ProductEntity temp = obj as ProductEntity;
            return (temp.ProductName.IndexOf(search_text_box.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0
                 || temp.ProductID.ToString().IndexOf(search_text_box.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0
                 || temp.Brand.IndexOf(search_text_box.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0
                 || temp.Type.IndexOf(search_text_box.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0);
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
                Dispatcher.Invoke(() =>
                                       {
                                           products =
                                               dao.getAll(typeof(ProductEntity)) as List<ProductEntity>;

                                           products.RemoveAll(entity => entity.Quantity > 5);
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