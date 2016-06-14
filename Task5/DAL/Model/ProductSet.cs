using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public partial class ProductSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<OrderSet> OrderSet { get; set; }
    }
}