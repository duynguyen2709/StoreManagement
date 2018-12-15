using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            ProductEntity newProduct = new ProductEntity();
            newProduct.ProductName = txt_Name.Text;
            newProduct.Type = txt_Type.Text;
            newProduct.Brand = txt_Brand.Text;
            newProduct.Price = int.Parse(txt_Price.Text);
            newProduct.Quantity = int.Parse(txt_Quantity.Text);
            newProduct.ImageURL = txt_URLimage.Text;
            newProduct.Description = txt_Description.Text;
            BaseDAO dao = BaseDAO.getInstance();
            dao.insert(newProduct);
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.Equals(txt_Name.Text.ToString().Trim().ToLower(),""))
            {
                btn_Add.IsEnabled = false;
            }
            else
            {
                btn_Add.IsEnabled = true;
            }
        }

        private void txt_Price_TextChanged(object sender, TextChangedEventArgs e)
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
        private void txt_Type_TextChanged(object sender, TextChangedEventArgs e)
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
        private void txt_Brand_TextChanged(object sender, TextChangedEventArgs e)
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
        private void txt_Quantity_TextChanged(object sender, TextChangedEventArgs e)
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
    }
}
