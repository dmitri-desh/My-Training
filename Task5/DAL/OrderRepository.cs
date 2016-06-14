using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class OrderRepository
    {
        private static ICollection<OrderSet> list = new List<OrderSet>();

        public IEnumerable<OrderSet> GetAll()
        {
            return list;
        }
    }
}
