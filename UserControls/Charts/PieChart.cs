using StoreManagement.DAO;
using StoreManagement.Entities;
using System;
using System.Collections.Generic;

namespace StoreManagement.UserControls.Charts
{
    internal class PieChart : ChartData
    {
        #region ChartConstant

        private static readonly string ChartColor = "&chco=f73838|11d864|3891f7|FFFF00|31b786";
        private static readonly string ChartSize = "&chs=400x200";
        private static readonly string ChartType = "cht=p";

        #endregion ChartConstant

        public static string DrawChart(ChartData.TimeSpan time)
        {
            InitChartValue(time);

            string ChartData = "&chd=t:";
            string ChartLabel = "&chl=";
            string ChartLegend = "&chdl=";

            using (StoreManagementEntities context = new StoreManagementEntities())
            {
                foreach (KeyValuePair<int, int> product in TopProduct)
                {
                    ChartData += product.Value + ",";
                    ChartLabel += product.Value + "|";

                    string name = context.Products.Find(product.Key).ProductName;
                    name = name.Replace(" ", "+");
                    if (name.Length > 20)
                    {
                        name = name.Substring(0, 20) + "...";
                    }

                    ChartLegend += name + "|";
                }
            }

            ChartData = ChartData.Remove(ChartData.Length - 1);
            ChartLabel = ChartLabel.Remove(ChartLabel.Length - 1);
            ChartLegend = ChartLegend.Remove(ChartLegend.Length - 1);

            return BaseChartURL
                 + ChartType
                 + ChartColor
                 + ChartSize
                 + ChartData
                 + ChartLabel
                 + ChartLegend;
        }

        private static Dictionary<int, int> TopProduct = new Dictionary<int, int>();

        private static void InitChartValue(ChartData.TimeSpan time)
        {
            Dictionary<int, int> AllProduct = new Dictionary<int, int>();

            List<BillEntity> ListBillData = ChartsLayout.ListBillData.GetRange(0, ChartsLayout.ListBillData.Count);

            //remove bills
            switch (time)
            {
                case TimeSpan._7Days:
                    int day = 7;
                    ListBillData.RemoveAll(entity => (DateTime.Today - entity.BillDate).Days >= day);

                    break;

                case TimeSpan._15Days:
                    day = 15;
                    ListBillData.RemoveAll(entity => (DateTime.Today - entity.BillDate).Days >= day);

                    break;

                case TimeSpan._4Weeks:
                    DateTime startOfWeek = DateTime.Today;

                    while (startOfWeek.DayOfWeek != DayOfWeek.Monday)
                    {
                        startOfWeek = startOfWeek.AddDays(-1);
                    }

                    List<DateTime> temp = new List<DateTime>();

                    for (int i = 3; i >= 0; i--)
                    {
                        DateTime monday = startOfWeek.AddDays(-i * 7);

                        temp.Add(monday);
                    }

                    ListBillData.RemoveAll(entity => entity.BillDate < temp[0]);

                    break;

                case TimeSpan._6Months:
                    DateTime startOfMonth = DateTime.Today;

                    while (startOfMonth.Day != 1)
                    {
                        startOfMonth = startOfMonth.AddDays(-1);
                    }

                    List<DateTime> ListStartOfMonth = new List<DateTime>();

                    for (int i = 0; i < 6; i++)
                    {
                        while (startOfMonth.Day != 1)
                        {
                            startOfMonth = startOfMonth.AddDays(-1);
                        }

                        startOfMonth = startOfMonth.AddDays(-1);
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        while (startOfMonth.Day != 1)
                        {
                            startOfMonth = startOfMonth.AddDays(1);
                        }

                        ListStartOfMonth.Add(startOfMonth);
                        startOfMonth = startOfMonth.AddDays(1);
                    }

                    ListBillData.RemoveAll(entity => entity.BillDate < ListStartOfMonth[0]);

                    break;
            }

            foreach (BillEntity bill in ListBillData)
            {
                foreach (KeyValuePair<int, int> product in bill.ListProduct)
                {
                    if (AllProduct.ContainsKey(product.Key))
                    {
                        AllProduct[product.Key] += product.Value;
                    }
                    else
                    {
                        AllProduct.Add(product.Key, product.Value);
                    }
                }
            }

            TopProduct = new Dictionary<int, int>();

            for (int i = 0; i < 5; i++)
            {
                int max = -1;
                int prodID = -1;
                foreach (KeyValuePair<int, int> product in AllProduct)
                {
                    if (product.Value >= max)
                    {
                        max = product.Value;
                        prodID = product.Key;
                    }
                }

                if (prodID != -1)
                {
                    TopProduct.Add(prodID, max);
                    AllProduct.Remove(prodID);
                }
            }
        }
    }
}