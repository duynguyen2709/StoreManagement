using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.UserControls
{
    public class infobasket
    {
        public int Number { get; set; }
        public string Brand { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public long Price { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }
        public long sum;
        public long Sum
        {
            get { return sum; }
            set
            {
                sum = value;

            }
        }
        public int size;
        public int Size
        {
            get { return size; }
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
            this.Size = size;
            this.Sum = Size * Price;
            this.Number = 0;
            
        }
    }
}
