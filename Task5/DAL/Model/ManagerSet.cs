using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Model
{
    public partial class ManagerSet
    {
        public int Id { get; set; }
        public string SecondName { get; set; }
        public virtual ICollection<OrderSet> OrderSet { get; set; }
    }
}
