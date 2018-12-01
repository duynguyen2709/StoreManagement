namespace StoreManagement.Entities
{
    internal class ProductEntity
    {
        public ProductEntity()
        {
        }

        public string Brand { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public long Price { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return (GetType().Name + $"(ID:{ProductID})");
        }
    }
}