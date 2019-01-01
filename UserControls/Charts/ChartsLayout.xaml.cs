using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace StoreManagement.UserControls.Charts
{
    /// <summary>
    /// Interaction logic for ChartsLayout.xaml
    /// </summary>
    public partial class ChartsLayout : UserControl
    {
        public static List<BillEntity> ListBillData = new List<BillEntity>();

        public ChartsLayout()
        {
            InitializeComponent();

            cbbTime.SelectedIndex = 0;

            InitChart();
        }

        protected static DateTime Today = DateTime.Today;

        private string DrawBarChart()
        {
            int index = cbbTime.SelectedIndex;

            ChartData.TimeSpan time = (ChartData.TimeSpan)index;

            //LineChart.DrawChart(ChartData.GetDays(time));
            return "";
        }

        private string DrawLineChart()
        {
            int index = cbbTime.SelectedIndex;

            ChartData.TimeSpan time = (ChartData.TimeSpan)index;

            string url = LineChart.DrawChart(ChartData.GetDays(time));

            lineChart.Source = new BitmapImage(new Uri(url));
            return url;
        }

        private string DrawPieChart()
        {
            int index = cbbTime.SelectedIndex;

            ChartData.TimeSpan time = (ChartData.TimeSpan)index;

            //LineChart.DrawChart(ChartData.GetDays(time));

            return "";
        }

        private async void InitChart()
        {
            loadingGif.Visibility = Visibility.Visible;
            mainPanel.Visibility = Visibility.Hidden;
            await Task.Run(() =>
                              {
                                  BaseDAO dao = new BillDAO();
                                  ListBillData = dao.getAll() as List<BillEntity>;

                                  Dispatcher.Invoke(() =>
                                                    {
                                                        DrawLineChart();
                                                    });

                                  //DrawPieChart();
                                  // DrawBarChart();
                              });

            loadingGif.Visibility = Visibility.Hidden;
            mainPanel.Visibility = Visibility.Visible;
        }
    }
}