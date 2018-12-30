using StoreManagement.DAO;
using StoreManagement.Entities;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

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

            ProductEntity newProduct = new ProductEntity
            {
                ProductName = txt_Name.Text.Trim(),
                Type = txt_Type.Text.Trim(),
                Brand = txt_Brand.Text.Trim(),
                Price = int.Parse(txt_Price.Text.Trim()),
                Quantity = int.Parse(txt_Quantity.Text.Trim()),
                ImageURL = txt_URLimage.Text.Trim(),
                Description = txt_Description.Text.Trim()
            };
            BaseDAO dao = BaseDAO.getInstance();
            dao.insert(newProduct);

            MessageBox.Show("Thêm sản phẩm thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private bool checkValue()
        {
            return (!string.Equals(txt_Name.Text.Trim().ToLower(), "")
                 && !string.Equals(txt_Price.Text.Trim().ToLower(), "")
                 && !string.Equals(txt_Brand.Text.Trim().ToLower(), "")
                 && !string.Equals(txt_Description.Text.Trim().ToLower(), "")
                 && !string.Equals(txt_Quantity.Text.Trim().ToLower(), "")
                 && !string.Equals(txt_Type.Text.Trim().ToLower(), "")
                 && !string.Equals(txt_URLimage.Text.Trim().ToLower(), ""));
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}