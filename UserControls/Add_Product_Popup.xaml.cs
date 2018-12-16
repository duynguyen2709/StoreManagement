using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using StoreManagement.DAO;
using StoreManagement.Entities;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for Add_Product_Popup.xaml
    /// </summary>
    public partial class Add_Product_Popup : Window
    {
        public Add_Product_Popup()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (checkValue() == false)
            {
                MessageBox.Show("Chưa điền đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            ProductEntity newProduct = new ProductEntity();
            newProduct.ProductName = txt_Name.Text.Trim();
            newProduct.Type = txt_Type.Text.Trim();
            newProduct.Brand = txt_Brand.Text.Trim();
            newProduct.Price = int.Parse(txt_Price.Text.Trim());
            newProduct.Quantity = int.Parse(txt_Quantity.Text.Trim());
            newProduct.ImageURL = txt_URLimage.Text.Trim();
            newProduct.Description = txt_Description.Text.Trim();
            BaseDAO dao = BaseDAO.getInstance();
            dao.insert(newProduct);

            MessageBox.Show("Thêm sản phẩm thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private bool checkValue()
        {
            return (!String.Equals(txt_Name.Text.Trim().ToLower(), "")
                 && !String.Equals(txt_Price.Text.Trim().ToLower(), "")
                 && !String.Equals(txt_Brand.Text.Trim().ToLower(), "")
                 && !String.Equals(txt_Description.Text.Trim().ToLower(), "")
                 && !String.Equals(txt_Quantity.Text.Trim().ToLower(), "")
                 && !String.Equals(txt_Type.Text.Trim().ToLower(), "")
                 && !String.Equals(txt_URLimage.Text.Trim().ToLower(), ""));
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}