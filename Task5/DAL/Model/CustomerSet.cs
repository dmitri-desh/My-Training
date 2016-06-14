using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public partial class CustomerSet
    {
        public int Id { get; set; }
        public string SecondName { get; set; }
        public virtual ICollection<OrderSet> OrderSet { get; set; }
    }
}