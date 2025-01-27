using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart
{
    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsChecked { get; set; }

        
        public double GetTotalPrice()
        {
            return Price * Quantity;
        }

        
        public double GetDiscount(double discountPercentage)
        {
            return GetTotalPrice() * (discountPercentage / 100);
        }
    }
}
