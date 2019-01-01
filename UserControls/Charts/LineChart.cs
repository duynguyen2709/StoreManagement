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
        private static readonly string ChartDot = "&chm=o,FF9900,0,-1,8";
        private static readonly string ChartGrid = "&chg=10,10";
        private static readonly string ChartSize = "&chs=550x300";
        private static readonly string ChartTitle = "&chtt=Th%E1%BB%91ng+K%C3%AA+Doanh+Thu";
        private static readonly string ChartTitleSize = "&chts=13ad81,25,c";
        private static readonly string ChartType = "cht=lc";

        #endregion ChartConstant

        public static string DrawChart(int day)
        {
            InitChartValue(day);

            string ChartValue = "&chd=t:0";
            string ChartXLabel = "&chxl=0:|.";

            foreach (KeyValuePair<DateTime, float> data in Revenue)
            {
                ChartValue += "," + data.Value.ToString("0.00");
                ChartXLabel += "|" + data.Key.Day + "/" + data.Key.Month;
            }

            return BaseChartURL
                 + ChartType
                 + ChartAutoScale
                 + ChartAxis
                 + ChartAxisColor
                 + ChartColor
                 + ChartDot
                 + ChartGrid
                 + ChartSize
                 + ChartTitle
                 + ChartTitleSize
                 + ChartDot
                 + ChartValue
                 + ChartXLabel;
        }

        private static Dictionary<DateTime, float> Revenue = new Dictionary<DateTime, float>();

        private static void InitChartValue(int day)
        {
            List<BillEntity> ListBillData = ChartsLayout.ListBillData.GetRange(0, ChartsLayout.ListBillData.Count);
            ListBillData.RemoveAll(entity => (DateTime.Today - entity.BillDate).Days >= day);

            for (int i = day - 1; i >= 0; i--)
            {
                Revenue.Add(DateTime.Today.AddDays(-i), 0);
            }

            foreach (BillEntity bill in ListBillData)
            {
                Revenue[bill.BillDate] += bill.TotalPrice * 1.0f / 1000000;
            }
        }
    }
}