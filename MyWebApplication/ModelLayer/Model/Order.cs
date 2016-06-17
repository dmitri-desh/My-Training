using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public partial class Order
    {
        public int Id { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public int ProductId { get; set; }
        public int ManagerId { get; set; }
        public int CustomerId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
