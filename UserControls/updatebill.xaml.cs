using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private List<BillEntity> bills = new List<BillEntity>();
        private BaseDAO dao = new BillDAO();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IDbill.Text != "")
            {
                try
                {
                    bills.Clear();
                    BillEntity bill = dao.get(Int32.Parse(IDbill.Text), typeof(BillEntity)) as BillEntity;
                    if (bill != null)
                    {
                        bills.Add(bill);
                        listbillupdate.ItemsSource = bills;
                        listbillupdate.Items.Refresh();
                    }
                }
                catch { }
            }
            else
            {
                try
                {
                    bills.Clear();
                    bills = dao.getAll(typeof(BillEntity)) as List<BillEntity>;
                    if (bills != null)
                    {
                        DateTime from = DateTime.Parse(Datefrom.Text);
                        DateTime to = DateTime.Parse(Dateto.Text);

                        for (int i = 0; i < bills.Count; i++)
                        {
                            if (!(from <= bills[i].BillDate && to >= bills[i].BillDate))
                            {
                                bills.RemoveAt(i);
                                i--;
                            }
                        }
                        listbillupdate.ItemsSource = bills;
                        listbillupdate.Items.Refresh();
                    }
                }
                catch { }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                BillEntity tmp = (BillEntity)btn.DataContext;

                var window = new updatedetailbill(tmp);
                window.ShowDialog();
            }
            catch { }
        }

        private void Listbillupdate_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void Listbillupdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            try
                            {
                                Button btn = (Button)sender;
                                BillEntity tmp = (BillEntity)btn.DataContext;
                                BaseDAO dao = new BillDAO();
                                dao.delete(tmp);
                                Infobill.flag = true;
                                bills.Clear();
                                listbillupdate.Items.Refresh();
                            }
                            catch { }
                        }
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
            catch { }
        }
    }
}