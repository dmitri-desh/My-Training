using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public partial class OrderSet
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Amount { get; set; }
        public int ManagerId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public virtual CustomerSet CustomerSet { get; set; }
        public virtual ManagerSet ManagerSet { get; set; }
        public virtual ProductSet ProductSet { get; set; }
    }
}