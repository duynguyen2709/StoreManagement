namespace StoreManagement.UserControls.Charts
{
    public class ChartData
    {
        public ChartData()
        {
        }

        public enum TimeSpan
        {
            Weekly,
            _15Days,
            Monthly
        }

        public static int GetDays(TimeSpan time)
        {
            int day = 7;

            switch (time)
            {
                case TimeSpan.Weekly:
                    day = 7;

                    break;

                case TimeSpan._15Days:
                    day = 15;

                    break;

                case TimeSpan.Monthly:
                    day = 30;

                    break;
            }

            return day;
        }

        protected static readonly string BaseChartURL = "https://chart.googleapis.com/chart?";
    }
}