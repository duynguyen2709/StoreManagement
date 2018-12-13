using StoreManagement.DAO;
using StoreManagement.Entities;
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
    /// Interaction logic for updatebill.xaml
    /// </summary>
    public partial class updatebill : UserControl
    {
        BaseDAO dao = new BillDAO();
        List<BillEntity> bills=new List<BillEntity>();
        public static BillEntity billdetail;
        


        public updatebill()
        {
            InitializeComponent();
            listbillupdate.ItemsSource = bills;


        }
        public void GetBill()
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
                bills.Clear();
                bills = dao.getAll(typeof(BillEntity)) as List<BillEntity>;
                try
                {
                    if (bills != null)
                    {
                        if (IDCashier.Text != "")
                        {
                            for (int i = 0; i < bills.Count; i++)
                            {

                                if (Int32.Parse(IDCashier.Text) != bills[i].CashierID)
                                {
                                    bills.RemoveAt(i);
                                    i--;
                                }
                            }
                            try
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
                            }
                            catch
                            {

                            }
                            listbillupdate.ItemsSource = bills;
                            listbillupdate.Items.Refresh();
                        }
                        else
                        {
                            DateTime from = DateTime.Parse(Datefrom.Text);
                            DateTime to = DateTime.Parse(Dateto.Text);
                            for (int i = 0; i < bills.Count; i++)
                            {

                                if (!(from <= bills[i].BillDate && to >= bills[i].BillDate) )
                                {
                                    bills.RemoveAt(i);
                                    i--;
                                }
                            }
                            listbillupdate.ItemsSource = bills;
                            listbillupdate.Items.Refresh();
                        }




                    }
                }
                catch { }
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetBill();
            
        }

        private void Listbillupdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
        }

        private void Listbillupdate_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Button btn = (Button)sender;
                BillEntity tmp = (BillEntity)btn.DataContext;
                
                var window = new updatedetailbill(tmp);
                window.ShowDialog();
                if(updatedetailbill.isUpdate==true)
                {
                    GetBill();
                    updatedetailbill.isUpdate = false;

                }
                
            }
            catch { }
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
            catch { }
        }

        private void UserControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void UserControl_ToolTipClosing(object sender, ToolTipEventArgs e)
        {

        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            //if(Infobill.flag==true)
            //{
            //    bills.Clear();
            //    GetBill();
            //}
        }
    }
}
