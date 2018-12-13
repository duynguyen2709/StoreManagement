using StoreManagement.DAO;
using StoreManagement.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for updatedetailbill.xaml
    /// </summary>
    public partial class updatedetailbill : Window
    {
        public static bool isUpdate = false;

        public updatedetailbill(BillEntity tmp)
        {
            InitializeComponent();
            billdetail = tmp;

            //Chuyen Dictionary thanh dạng list<value>

            var listproductbill = billdetail.ListProduct;

            //Lay Product để lay quantity
            BaseDAO dao = new ProductDAO();
            List<int> array1 = new List<int>(listproductbill.Keys.ToList());
            List<int> array2 = new List<int>(listproductbill.Values.ToList());
            for (int i = 0; i < array1.Count; i++)
            {
                ProductEntity user = dao.get(array1[i], typeof(ProductEntity)) as ProductEntity;
                array.Add(new info(array1[i], array2[i], user.Quantity));
            }

            listdetailbill.ItemsSource = array;
        }

        public Dictionary<int, int> convertListinfotoDictionary()
        {
            Dictionary<int, int> tmp = new Dictionary<int, int>();
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i].Value >= 0)
                    tmp.Add(array[i].Key, array[i].Value);
            }
            return tmp;
        }

        public class info
        {
            public bool flag = false;
            public int value;

            public info(int a, int b, int c)
            {
                Key = a;
                Value = b;
                Quantity = c;
                flag = true;
            }

            public int Key { set; get; }

            public int Quantity { set; get; }

            public int Value
            {
                get => value;

                set
                {
                    if (flag == true)
                    {
                        if (value < 0)
                        {
                            this.value = 0;
                        }
                        else if (value <= Quantity)
                        {
                            this.value = value;
                        }
                        else
                        {
                            this.value = Quantity;
                        }
                    }
                    else
                    {
                        this.value = value;
                    }
                }
            }
        }

        private List<info> array = new List<info>();
        private BillEntity billdetail;

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Update bill detail ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            try
                            {
                                // convert to DICTIONARY
                                Dictionary<int, int> detailbill = convertListinfotoDictionary();

                                //Update bill
                                billdetail.ListProduct = detailbill;
                                BaseDAO dao = new BillDAO();
                                dao.update(billdetail);
                                Infobill.flag = true;
                                isUpdate = true;
                                this.Close();
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