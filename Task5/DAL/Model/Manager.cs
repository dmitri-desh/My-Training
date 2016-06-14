using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Model
{
    public partial class Manager
    {
        public int Id { get; set; }
        public string SecondName { get; set; }
        public virtual ICollection<Order> OrderSet { get; set; }
    }
}
