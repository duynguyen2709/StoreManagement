using StoreManagement.DAO;
using StoreManagement.Entities;
using StoreManagement.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for Infobill.xaml
    /// </summary>
    public partial class Infobill : Window
    {
        //bao hieu update listitem
        public static bool flag = false;

        public Infobill()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    //cap nhat database
                    //cap nhat BillHistory
                    //cap nhat Detail Bill
                    //init
                    //BaseDAO dao1 = BaseDAO
                    int tmpIdCashier = LoginForm.Idcashier;

                    //chuyen sale.basket sang dang directory
                    Dictionary<int, int> tmpbasket = new Dictionary<int, int>();

                    foreach (var t in sale.baskets)
                    {
                        tmpbasket.Add(t.ProductID, t.size);
                    }

                    //create new bill
                    BillEntity bill = new BillEntity()
                    {
                        //set date
                        BillDate = DateTime.Today,

                        //add list product
                        ListProduct = tmpbasket,

                        //set ID cashier
                        CashierID = tmpIdCashier
                    };

                    //insert and get new bill ID
                    BaseDAO dao = new BillDAO();
                    int billID = dao.insert(bill);

                    //bao hieu cap nhat listitems
                    flag = true;

                    MessageBox.Show("Thanh toán thành công",
                                    "Result",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    this.Close();
                    sale.baskets.Clear();
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        private void Receive_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Receive_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (receive.Text != "" && total.Text != "")
                {
                    if ((long.Parse(receive.Text) - long.Parse(total.Text)) >= 0)
                    {
                        decimal value = 0.00M;

                        value = Convert.ToDecimal((long.Parse(receive.Text) - long.Parse(total.Text)));

                        sparecash.Text = value.ToString("C");
                        confirm.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        confirm.Visibility = Visibility.Collapsed;
                        sparecash.Text = "";
                    }
                }
            }
            catch { }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listbill.ItemsSource = sale.baskets;

            long tong = 0;
            for (int i = 0; i < sale.baskets.Count(); i++)
            {
                sale.baskets[i].Number = i + 1;
                long z = sale.baskets[i].Price;

                tong += z * sale.baskets[i].Size;
            }

            total.Text = tong.ToString();
        }
    }
}