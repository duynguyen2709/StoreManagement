﻿using StoreManagement.DAO;
using StoreManagement.Entities;
using StoreManagement.UserControls.Charts;
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

                if (Datefrom.Text.Length > 0)
                {
                    bills.RemoveAll(entity => DateTime.Parse(Datefrom.Text) > entity.BillDate);
                }

                if (Dateto.Text.Length > 0)
                {
                    bills.RemoveAll(entity => DateTime.Parse(Dateto.Text) < entity.BillDate);
                }

                //bills.RemoveAll(entity => !(DateTime.Parse(Datefrom.Text) <= entity.BillDate
                //                        && DateTime.Parse(Dateto.Text) >= entity.BillDate));

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
                    MessageBox.Show("Bills Not Found",
                                    "Result",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error Occurred. Please Try Again",
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
            if (Datefrom.Text.Length == 0 && Dateto.Text.Length == 0)
            {
                MessageBox.Show("Please Fill in Date fields",
                                "Information",
                                MessageBoxButton.OK,
                                MessageBoxImage.Asterisk);

                return;
            }
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

                    Task.Run(() => Dispatcher.Invoke(ChartsLayout.ReloadChart));
                }
            }
            catch
            {
                MessageBox.Show("Error Occurred. Please Try Again",
                                   "Error",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Error);
            }
        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result =
                    MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

                switch (result)
                {
                    case MessageBoxResult.Yes:

                        {
                            try
                            {
                                BillEntity tmp = (sender as Button).DataContext as BillEntity;
                                Task.Run(() =>
                                         {
                                             dao.delete(tmp);
                                             Dispatcher.Invoke(ChartsLayout.ReloadChart);
                                         });
                                Infobill.flag = true;

                                BillEntity delObject = ListBill.Find(entity => tmp.BillID == entity.BillID);
                                ListBill.Remove(delObject);

                                MessageBox.Show("Delete Bill Success",
                                                "Result",
                                                MessageBoxButton.OK,
                                                MessageBoxImage.Information);
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
                MessageBox.Show("Error Occurred. Please Try Again",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}