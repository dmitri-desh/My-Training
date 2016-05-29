using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Order
    {
        public DateTime PurchaseDate { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public Order (DateTime purchaseDate, string managerName, string customerName, string productName, string amount)
        {
            this.PurchaseDate = purchaseDate;
            this.ManagerName = managerName;
            this.CustomerName = customerName;
            this.ProductName = productName;
            this.Amount = Convert.ToDecimal(amount);
        }
    }
}
