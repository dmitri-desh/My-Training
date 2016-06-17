using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public partial class Manager
    {
        public Manager()
        {
            this.orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string SecondName { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
