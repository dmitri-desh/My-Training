using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task02
{
    class Order
    {
        private List<OrderLine> _orderLines = new List<OrderLine>();

        public void AddOrderLine(string product, int quantity, double price)
        {
            OrderLine line = new OrderLine();
            line.ProductName = product;
            line.Quantity = quantity;
            line.Price = price;
            _orderLines.Add(line);
        }

        public double GetOrderTotal()
        {
            double total = 0;
            foreach (OrderLine line in _orderLines)
            {
                total += line.GetOrderLineTotal();
            }
            return total;
        }

        public void GetOrder()
        {
            foreach (OrderLine line in _orderLines)
            {
                Console.WriteLine("{0}", line.GetOrderLine(line));
            }
            
        }

        // Nested class
        private class OrderLine
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }

            public double GetOrderLineTotal()
            {
                return Price * Quantity;
            }
            public string GetOrderLine (OrderLine orderLine)
            {
                return (orderLine.ProductName.ToString().PadRight(10)
                       + "\t" + orderLine.Quantity.ToString("D0", CultureInfo.CurrentCulture).PadRight(3)
                       + "\t" + orderLine.Price.ToString   ("C2", CultureInfo.CurrentCulture).PadRight(5)
                       + "\t" + orderLine.GetOrderLineTotal().ToString("C2", CultureInfo.CurrentCulture).PadRight(5)
                       );
            }
        }
    }
}
