using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            BaseDAO dao = BaseDAO.getInstance();
            listitems = new ObservableCollection<ProductEntity>((dao.getAll(typeof(ProductEntity)) as List<ProductEntity>));
            listitem.ItemsSource = listitems;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listitem.ItemsSource);
            view.Filter = UserFilter;
            PropertyGroupDescription group = new PropertyGroupDescription("Type");
            view.GroupDescriptions.Add(group);
        }

        private ObservableCollection<ProductEntity> listitems;

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
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
                if (flag == 0)
                {
                    baskets.Add(new infobasket(tmp.Brand, tmp.Description, tmp.ImageURL, tmp.Price,
                    tmp.ProductID, tmp.ProductName, tmp.Quantity, 1));
                }
            }
            catch
            { }
        }

        private void Listitem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listitem.ItemsSource).Refresh();
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

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Infobill.flag == true)
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
            if (String.IsNullOrEmpty(search.Text))
                return true;
            else
                return ((item as ProductEntity).ProductName.IndexOf(search.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}