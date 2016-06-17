using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public partial class Product
    {
        public Product()
        {
            this.orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
