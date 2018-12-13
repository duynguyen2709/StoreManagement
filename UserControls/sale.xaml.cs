using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// Interaction logic for sale.xaml
    /// </summary>
    public partial class sale : UserControl
    {
        ObservableCollection<ProductEntity> listitems;
        public static ObservableCollection<infobasket> baskets = new ObservableCollection<infobasket>();

        public sale()
        {
            
            InitializeComponent();
            BaseDAO dao = BaseDAO.getInstance();
            listitems = new ObservableCollection<ProductEntity>((dao.getAll(typeof(ProductEntity)) as List<ProductEntity>));
            listitem.ItemsSource = listitems;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listitem.ItemsSource);
            view.Filter = UserFilter;

            PropertyGroupDescription group = new PropertyGroupDescription("Type");
            view.GroupDescriptions.Add(group);
            listbill.ItemsSource = baskets;

            baskets.CollectionChanged += this.OnCollectionChanged;


        }
        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            long sum = 0;
            if(baskets.Count==0)
            {
                if (Infobill.flag == true)
                {
                    updatelistitem();
                    Infobill.flag = false;
                }
            }
            for(int i=0;i<baskets.Count;i++)
            {
                sum += baskets[i].Sum;
            }
            decimal value = 0.00M;
            value = Convert.ToDecimal(sum);
            total.Text = value.ToString("C");

        }
            private void updatelistitem()
        {
            BaseDAO dao = new ProductDAO();
            listitems = new ObservableCollection<ProductEntity>((dao.getAll(typeof(ProductEntity)) as List<ProductEntity>));
            listitem.ItemsSource = listitems;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listitem.ItemsSource);
            view.Filter = UserFilter;
            PropertyGroupDescription group = new PropertyGroupDescription("Type");
            view.GroupDescriptions.Add(group);

        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(search.Text))
                return true;
            else
                return ((item as ProductEntity).ProductName.IndexOf(search.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listitem.ItemsSource).Refresh();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Listitem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try {
                ProductEntity tmp = (ProductEntity)listitem.SelectedItems[0];
                    int flag = 0;
                    for (int i = 0; i < baskets.Count(); i++)
                    {

                        if (tmp.ProductID == baskets[i].ProductID)
                        {
                            baskets[i].Size++;
                            flag = 1;
                            break;
                        }

                    }
                    if (flag == 0&&tmp.Quantity>0)
                    {
                        baskets.Add(new infobasket(tmp.Brand, tmp.Description, tmp.ImageURL, tmp.Price,
                        tmp.ProductID, tmp.ProductName, tmp.Quantity, 1));
                    }
                    listbill.Items.Refresh();
                    listitem.SelectedItems.Clear();
            }
            catch
            { }
            
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {

        }

        private void Listitem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Infobill.flag==true)
            {
                updatelistitem();
                Infobill.flag = false;
            }
        }

        private void Listitem_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProductEntity tmp = (ProductEntity)listitem.SelectedItems[0];
                    int flag = -1;
                    for (int i = 0; i < baskets.Count(); i++)
                    {

                        if (tmp.ProductID == baskets[i].ProductID)
                        {
                            baskets[i].Size--;
                            if (baskets[i].Size <= 0)
                                flag = i;
                            break;
                        }

                    }
                    if (flag != -1)
                    {

                        baskets.RemoveAt(flag);
                    }
                    listbill.Items.Refresh();
                    listitem.SelectedItems.Clear();
            }
            catch
            { }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        baskets.Clear();
                    }
                    break;
                case MessageBoxResult.No:
                    break;

            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            var tmp = new Infobill();
            tmp.ShowDialog();
        }

        private void UserControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            listbill.Items.Refresh();
            long sum = 0;
            for (int i = 0; i < baskets.Count; i++)
            {
                sum += baskets[i].Sum;
            }
            decimal value = 0.00M;
            value = Convert.ToDecimal(sum);
            total.Text = value.ToString("C");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            infobasket tmp = (infobasket)btn.DataContext;
            for (int i = 0; i < sale.baskets.Count(); i++)
            {
                if (tmp.ProductID == sale.baskets[i].ProductID)
                {
                    sale.baskets.RemoveAt(i);
                }
            }
        }

        private void Listbill_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Listbill_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
        
    }
}
