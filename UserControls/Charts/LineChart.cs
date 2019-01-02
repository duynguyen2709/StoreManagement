using StoreManagement.Entities;
using System;
using System.Collections.Generic;

namespace StoreManagement.UserControls.Charts
{
    public class LineChart : ChartData
    {
        #region ChartConstant

        private static readonly string ChartAutoScale = "&chds=a";
        private static readonly string ChartAxis = "&chxt=x,y";
        private static readonly string ChartAxisColor = "&chxs=0N,000000|1N*cUSD*Mil,FF0000";
        private static readonly string ChartColor = "&chco=00FF00";
        private static readonly string ChartColorFill = "&chf=bg,s,e8fff3";
        private static readonly string ChartDot = "&chm=o,FF9900,0,-1,8";
        private static readonly string ChartGrid = "&chg=10,10";
        private static readonly string ChartSize = "&chs=550x350";

        //private static readonly string ChartTitle = "&chtt=Th%E1%BB%91ng+K%C3%AA+Doanh+Thu";
        //private static readonly string ChartTitleSize = "&chts=13ad81,25,c";
        private static readonly string ChartType = "cht=lc";

        #endregion ChartConstant

        public static string DrawChart(ChartData.TimeSpan time)
        {
            InitChartValue(time);

            string ChartValue = "&chd=t:0";
            string ChartXLabel = "&chxl=0:|.";

            switch (time)
            {
                case TimeSpan._7Days:
                case TimeSpan._15Days:
                    foreach (KeyValuePair<DateTime, float> data in Revenue)
                    {
                        ChartValue += "," + data.Value.ToString("0.00");
                        ChartXLabel += "|" + data.Key.Day + "/" + data.Key.Month;
                    }

                    break;

                case TimeSpan._4Weeks:
                    foreach (KeyValuePair<DateTime, float> data in Revenue)
                    {
                        ChartValue += "," + data.Value.ToString("0.00");
                        ChartXLabel += "|" + data.Key.Day + "/" + data.Key.Month + "-" + data.Key.AddDays(6).Day + "/" + data.Key.AddDays(6).Month;
                    }
                    break;

                case TimeSpan._6Months:
                    foreach (KeyValuePair<DateTime, float> data in Revenue)
                    {
                        ChartValue += "," + data.Value.ToString("0.00");
                        ChartXLabel += "|" + data.Key.Month + "/" + data.Key.Year;
                    }
                    break;
            }

            return BaseChartURL
                 + ChartType
                 + ChartAutoScale
                 + ChartColorFill
                 + ChartAxis
                 + ChartAxisColor
                 + ChartColor
                 + ChartDot
                 + ChartGrid
                 + ChartSize
                 + ChartDot
                 + ChartValue
                 + ChartXLabel;
        }

        private static Dictionary<DateTime, float> Revenue = new Dictionary<DateTime, float>();

        private static void InitChartValue(ChartData.TimeSpan time)
        {
            Revenue = new Dictionary<DateTime, float>();

            List<BillEntity> ListBillData = ChartsLayout.ListBillData.GetRange(0, ChartsLayout.ListBillData.Count);

            switch (time)
            {
                case TimeSpan._7Days:
                    int day = 7;
                    ListBillData.RemoveAll(entity => (DateTime.Today - entity.BillDate).Days >= day);
                    for (int i = day - 1; i >= 0; i--)
                    {
                        Revenue.Add(DateTime.Today.AddDays(-i), 0);
                    }

                    foreach (BillEntity bill in ListBillData)
                    {
                        Revenue[bill.BillDate] += bill.TotalPrice * 1.0f / 1000000;
                    }
                    break;

                case TimeSpan._15Days:
                    day = 15;
                    ListBillData.RemoveAll(entity => (DateTime.Today - entity.BillDate).Days >= day);
                    for (int i = day - 1; i >= 0; i--)
                    {
                        Revenue.Add(DateTime.Today.AddDays(-i), 0);
                    }

                    foreach (BillEntity bill in ListBillData)
                    {
                        Revenue[bill.BillDate] += bill.TotalPrice * 1.0f / 1000000;
                    }
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
                        Revenue.Add(monday, 0);
                        temp.Add(monday);
                    }

                    ListBillData.RemoveAll(entity => entity.BillDate < temp[0]);

                    foreach (BillEntity bill in ListBillData)
                    {
                        foreach (DateTime date in temp)
                        {
                            int dayDiff = (bill.BillDate - date).Days;
                            if (dayDiff >= 0 && dayDiff <= 6)
                            {
                                Revenue[date] += bill.TotalPrice * 1.0f / 1000000;
                            }
                        }
                    }

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

                        Revenue.Add(startOfMonth, 0);
                        ListStartOfMonth.Add(startOfMonth);
                        startOfMonth = startOfMonth.AddDays(1);
                    }

                    ListBillData.RemoveAll(entity => entity.BillDate < ListStartOfMonth[0]);

                    foreach (BillEntity bill in ListBillData)
                    {
                        foreach (DateTime date in ListStartOfMonth)
                        {
                            if (bill.BillDate.Month == date.Month && bill.BillDate.Year == date.Year)
                            {
                                Revenue[date] += bill.TotalPrice * 1.0f / 1000000;
                            }
                        }
                    }

                    break;
            }
        }
    }
}