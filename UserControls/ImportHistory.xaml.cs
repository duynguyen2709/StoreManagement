using StoreManagement.DAO;
using StoreManagement.Entities;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StoreManagement.UserControls
{
    /// <summary>
    /// Interaction logic for ImportHistory.xaml
    /// </summary>
    public partial class ImportHistory : UserControl
    {
        public ImportHistory()
        {
            InitializeComponent();

            instance = this;
            RefreshImportHistory();
        }

        public static void RefreshImportHistory()
        {
            ListBindingEntity = new List<ImportHistoryEntity>();

            BaseDAO dao = new GoodsImportDAO();
            ListGoodsImportEntity = dao.getAll(typeof(GoodsImportEntity)) as List<GoodsImportEntity>;

            dao = new ProductDAO();
            ProductEntity product = new ProductEntity();
            foreach (GoodsImportEntity entity in ListGoodsImportEntity)
            {
                product = dao.get(entity.ProductID) as ProductEntity;
                ListBindingEntity.Add(new ImportHistoryEntity()
                {
                    ImportDate = entity.ImportDate,
                    ProductID = entity.ProductID,
                    ProductName = product.ProductName,
                    Quantity = entity.Quantity
                });
            }

            instance.listview.ItemsSource = ListBindingEntity;
            instance.listview.Items.Refresh();
        }

        private static ImportHistory instance;
        private static List<ImportHistoryEntity> ListBindingEntity = new List<ImportHistoryEntity>();

        private static List<GoodsImportEntity> ListGoodsImportEntity = new List<GoodsImportEntity>();

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
                                ImportHistoryEntity tmp = (sender as Button).DataContext as ImportHistoryEntity;

                                GoodsImportEntity entity = new GoodsImportEntity()
                                {
                                    ImportDate = tmp.ImportDate,
                                    ProductID = tmp.ProductID,
                                    Quantity = tmp.Quantity
                                };

                                (new GoodsImportDAO()).delete(entity);
                                RefreshImportHistory();

                                MessageBox.Show("Xóa đơn nhập hàng thành công",
                                                "Result",
                                                MessageBoxButton.OK,
                                                MessageBoxImage.Information);

                                Import_Product.LoadMain();
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

        private class ImportHistoryEntity : GoodsImportEntity
        {
            public string ProductName { get; set; }
        }
    }
}