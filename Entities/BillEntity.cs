using System;
using System.Collections.Generic;

namespace StoreManagement.Entities
{
    public partial class BillEntity
    {
        public BillEntity()
        {
            ListProduct = new Dictionary<int, int>();
        }

        public DateTime BillDate { get; set; }

        public int BillID { get; set; }

        public int CashierID { get; set; }

        // <ProductID , Quantity>
        public Dictionary<int, int> ListProduct { get; set; }

        public long TotalPrice { get; set; }

        public override string ToString()
        {
            return (GetType().Name + $"(ID:{BillID})");
        }
    }
}