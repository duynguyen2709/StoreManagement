namespace StoreManagement.UserControls.Charts
{
    public class ChartData
    {
        public ChartData()
        {
        }

        public enum TimeSpan
        {
            _7Days,
            _15Days,
            _4Weeks,
            _6Months
        }

        public static int GetDays(TimeSpan time)
        {
            int day = 7;

            switch (time)
            {
                case TimeSpan._7Days:
                    day = 7;

                    break;

                case TimeSpan._15Days:
                    day = 15;

                    break;

                case TimeSpan._4Weeks:
                    day = 28;

                    break;

                case TimeSpan._6Months:
                    day = 180;

                    break;
            }

            return day;
        }

        protected static readonly string BaseChartURL = "https://chart.googleapis.com/chart?";
    }
}