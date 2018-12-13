using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
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
            listbillupdate.ItemsSource = bills;
        }

        public void GetBill()
        {
            try
            {
                bills.Clear();
                bills = dao.getAll(typeof(BillEntity)) as List<BillEntity>;

                if (bills != null)
                {
                    bills.RemoveAll(entity => !(DateTime.Parse(Datefrom.Text) <= entity.BillDate
                                              && DateTime.Parse(Dateto.Text) >= entity.BillDate));

                    if (IDCashier.Text != "")
                    {
                        bills.RemoveAll(entity => entity.CashierID != Int32.Parse(IDCashier.Text));
                    }

                    if (bills.Count > 0)
                    {
                        listbillupdate.ItemsSource = bills;
                        listbillupdate.Items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bill",
                                        "Kết quả",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);
                    }
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

        private List<BillEntity> bills = new List<BillEntity>();
        private BaseDAO dao = new BillDAO();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetBill();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                BillEntity tmp = btn.DataContext as BillEntity;

                var window = new updatedetailbill(tmp);
                window.ShowDialog();
                if (updatedetailbill.isUpdate)
                {
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
                                Button btn = sender as Button;
                                BillEntity tmp = btn.DataContext as BillEntity;
                                BaseDAO dao = new BillDAO();
                                dao.delete(tmp);
                                Infobill.flag = true;

                                //lay lai bill tren database
                                bills.Clear();
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