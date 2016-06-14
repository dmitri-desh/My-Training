using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class OrderRepository
    {
        private static ICollection<Model.OrderSet> list = new List<Model.OrderSet>();

        public IEnumerable<Model.OrderSet> GetAll()
        {
            return list;
        }
    }
}
