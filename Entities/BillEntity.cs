using System;
using System.Collections.Generic;

namespace StoreManagement.Entities
{
    public partial class BillEntity
    {
        public BillEntity()
        {
            BillDate = DateTime.Today;
            ListProduct = new Dictionary<int, int>();
            TotalPrice = BillID = 0;
        }

        public DateTime BillDate { get; set; }

        public int BillID { get; set; }

        // <ProductID , Quantity>
        public Dictionary<int, int> ListProduct { get; set; }

        public long TotalPrice { get; set; }
    }
}