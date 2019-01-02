using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for sale.xaml
    /// </summary>
    public partial class sale : UserControl
    {
        public static ObservableCollection<infobasket> baskets = new ObservableCollection<infobasket>();

        public sale()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    BaseDAO dao = BaseDAO.getInstance();
                    listitems = new ObservableCollection<ProductEntity>((dao.getAll(typeof(ProductEntity)) as List<ProductEntity>));
                    listitem.ItemsSource = listitems;
                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listitem.ItemsSource);
                    view.Filter = UserFilter;

                    PropertyGroupDescription group = new PropertyGroupDescription("Type");
                    view.GroupDescriptions.Add(group);
                    listbill.ItemsSource = baskets;

                    baskets.CollectionChanged += OnCollectionChanged;
                });
            });
        }

        private ObservableCollection<ProductEntity> listitems;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            infobasket tmp = (infobasket)btn.DataContext;
            for (int i = 0; i < baskets.Count(); i++)
            {
                if (tmp.ProductID == baskets[i].ProductID)
                {
                    baskets.RemoveAt(i);
                }
            }
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

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
        }

        private void Listbill_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void Listbill_SourceUpdated(object sender, DataTransferEventArgs e)
        {
        }

        private void Listitem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
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
                if (flag == 0 && tmp.Quantity > 0)
                {
                    baskets.Add(new infobasket(tmp.Brand, tmp.Description, tmp.ImageURL, tmp.Price,
                    tmp.ProductID, tmp.ProductName, tmp.Quantity, 1));
                }
                listbill.Items.Refresh();
                long sum = baskets.Sum(t => t.Sum);

                decimal value = 0.00M;
                value = Convert.ToDecimal(sum);
                total.Text = value.ToString("C");

                listitem.SelectedItems.Clear();
            }
            catch
            {
                // ignored
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
                        {
                            flag = i;
                        }

                        break;
                    }
                }
                if (flag != -1)
                {
                    baskets.RemoveAt(flag);
                }
                long sum = baskets.Sum(t => t.Sum);

                decimal value = 0.00M;
                value = Convert.ToDecimal(sum);
                total.Text = value.ToString("C");

                listbill.Items.Refresh();
                listitem.SelectedItems.Clear();
            }
            catch
            {
                // ignored
            }
        }

        private void Listitem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (baskets.Count == 0)
            {
                if (Infobill.flag)
                {
                    updatelistitem();
                    Infobill.flag = false;
                }
            }

            long sum = baskets.Sum(t => t.Sum);

            decimal value = 0.00M;
            value = Convert.ToDecimal(sum);
            total.Text = value.ToString("C");
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            Infobill tmp = new Infobill();
            tmp.ShowDialog();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listitem.ItemsSource).Refresh();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            listbill.Items.Refresh();
            long sum = baskets.Sum(t => t.Sum);
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

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void UserControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Infobill.flag)
            {
                updatelistitem();
                Infobill.flag = false;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(search.Text))
            {
                return true;
            }

            return ((item as ProductEntity).ProductName.IndexOf(search.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}