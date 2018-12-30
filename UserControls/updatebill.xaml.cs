using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for updatebill.xaml
    /// </summary>
    public partial class updatebill : UserControl
    {
        public static BillEntity billdetail;

        public updatebill()
        {
            InitializeComponent();
            LoadAllBillTask = GetAllBill();
        }

        public static async Task GetAllBill()
        {
            await Task.Run(() =>
                           {
                               ListBill = dao.getAll(typeof(BillEntity)) as List<BillEntity>;
                               firstLoaded = true;
                           });
        }

        public void GetBill()
        {
            try
            {
                List<BillEntity> bills = ListBill.GetRange(0, ListBill.Count);

                bills.RemoveAll(entity => !(DateTime.Parse(Datefrom.Text) <= entity.BillDate
                                         && DateTime.Parse(Dateto.Text) >= entity.BillDate));

                if (IDCashier.Text != "")
                {
                    bills.RemoveAll(entity => entity.CashierID != int.Parse(IDCashier.Text));
                }

                if (bills.Count > 0)
                {
                    listbillupdate.ItemsSource = bills;
                    listbillupdate.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn",
                                    "Result",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm. Vui lòng thử lại",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private static readonly BaseDAO dao = new BillDAO();
        private static bool firstLoaded = false;
        private static List<BillEntity> ListBill = new List<BillEntity>();
        private static Task LoadAllBillTask;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!firstLoaded)
            {
                loadingGif.Visibility = Visibility.Visible;
                listbillupdate.Visibility = Visibility.Collapsed;
                await LoadAllBillTask;
                loadingGif.Visibility = Visibility.Hidden;
                listbillupdate.Visibility = Visibility.Visible;
            }

            GetBill();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                BillEntity tmp = btn.DataContext as BillEntity;

                updatedetailbill window = new updatedetailbill(tmp);
                window.ShowDialog();
                if (updatedetailbill.isUpdate)
                {
                    // ListBill = dao.getAll(typeof(BillEntity)) as List<BillEntity>;
                    int index = ListBill.IndexOf(ListBill.Find(entity => tmp.BillID == entity.BillID));
                    BillEntity updBill = dao.get(tmp.BillID) as BillEntity;
                    ListBill[index].TotalPrice = updBill.TotalPrice;

                    GetBill();
                    updatedetailbill.isUpdate = false;
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật. Vui lòng thử lại",
                                   "Error",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Error);
            }
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void UserControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void UserControl_ToolTipClosing(object sender, ToolTipEventArgs e)
        {
        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result =
                    MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

                switch (result)
                {
                    case MessageBoxResult.Yes:

                        {
                            try
                            {
                                BillEntity tmp = (sender as Button).DataContext as BillEntity;
                                Task.Run(() => dao.delete(tmp));
                                Infobill.flag = true;

                                BillEntity delObject = ListBill.Find(entity => tmp.BillID == entity.BillID);
                                ListBill.Remove(delObject);
                                GetBill();
                            }
                            catch { }
                        }

                        break;

                    case MessageBoxResult.No:

                        break;
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa. Vui lòng thử lại",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}