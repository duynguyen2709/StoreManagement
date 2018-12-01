namespace StoreManagement.Entities
{
    internal class GoodsImportEntity
    {
        public GoodsImportEntity()
        {
        }

        public System.DateTime ImportDate { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return (GetType().Name + $"(Date : {ImportDate})");
        }
    }
}