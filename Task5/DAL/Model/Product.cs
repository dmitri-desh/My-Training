using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> OrderSet { get; set; }
    }
}