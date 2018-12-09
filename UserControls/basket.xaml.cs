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

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for basket.xaml
    /// </summary>
    public partial class basket : UserControl
    {
        public basket()
        {
            InitializeComponent();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        sale.baskets.Clear();

                        //var tmp = new loading();
                        //tmp.ShowDialog()

                        ;
                    }
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            long tong = 0;
            for (int i = 0; i < sale.baskets.Count(); i++)
            {
                long z = sale.baskets[i].Price;

                tong += z * sale.baskets[i].Size;
            }
            sum.Text = tong + "";
        }

        private void Listbill_IsHitTestVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            var tmp = new Infobill();
            tmp.ShowDialog();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            listbill.Items.Refresh();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            listbasket.Items.Refresh();
            listbill.Items.Refresh();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listbasket.ItemsSource = sale.baskets;
            listbill.ItemsSource = sale.baskets;
        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            infobasket tmp = (infobasket)btn.DataContext;
            for (int i = 0; i < sale.baskets.Count(); i++)
            {
                if (tmp.ProductName == sale.baskets[i].ProductName)
                {
                    sale.baskets.RemoveAt(i);
                }
            }
        }
    }
}