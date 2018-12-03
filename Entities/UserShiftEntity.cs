namespace StoreManagement.Entities
{
    internal class UserShiftEntity
    {
        public UserShiftEntity()
        {
        }

        public int CashierID { get; set; }

        public int Shift { get; set; }

        public int Week { get; set; }

        public string WeekDay { get; set; }

        public override string ToString()
        {
            return (GetType().Name + $"(CashierID: {CashierID} - Week: {Week} - WeekDay: {WeekDay} - Shift: {Shift})");
        }
    }
}