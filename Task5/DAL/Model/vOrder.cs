using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public partial class VOrder
    {
        public int OrderId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }

        public virtual Customer CustomerSet { get; set; }
        public virtual Manager ManagerSet { get; set; }
        public virtual Product ProductSet { get; set; }
    }
}