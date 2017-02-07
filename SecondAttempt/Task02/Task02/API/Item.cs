using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.API
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public Item (string name, decimal price, int qty)
        {
            Name = name;
            Price = price;
            Qty = qty;
        }
        public decimal GetAmount ()
        {
            return Price * Qty;
        }
        public override string ToString()
        {
            return Name.PadRight(10, ' ') + "\t" + Qty.ToString().PadLeft(5, ' ')
                                           + "\t" + Price.ToString().PadLeft(6, ' ')
                                           + "\t" + GetAmount().ToString("N2").PadLeft(6, ' ');
        }
    }
}
