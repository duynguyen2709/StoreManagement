namespace StoreManagement.UserControls.Charts
{
    public class ChartData
    {
        public ChartData()
        {
        }

        public enum TimeSpan
        {
            _3Days,
            Week,
            Month
        }

        private static readonly string ChartURL = "https://chart.googleapis.com/chart?";
    }
}