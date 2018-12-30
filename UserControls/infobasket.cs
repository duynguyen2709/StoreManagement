namespace StoreManagement.UserControls
{
    public class infobasket
    {
        public int size;

        public long sum;

        public infobasket(string Brand, string Description, string ImageURL, long Price,
                int ProductID, string ProductName, int Quantity, int size)
        {
            this.Brand = Brand;
            this.Description = Description;
            this.ImageURL = ImageURL;
            this.Price = Price;
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.Quantity = Quantity;
            Size = size;
            Sum = Size * Price;
            Number = 0;
        }

        public string Brand { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public int Number { get; set; }

        public long Price { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int Size
        {
            get => size;

            set
            {
                if (value < 0)
                {
                    size = 0;
                }
                else if (value <= Quantity)
                {
                    size = value;
                    Sum = Size * Price;
                }
                else
                {
                    size = Quantity;
                }
            }
        }

        public long Sum { get; set; }

        public string Type { get; set; }
    }
}