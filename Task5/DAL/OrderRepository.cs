using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class OrderRepository
    {
        private static ICollection<Model.Order> list = new List<Model.Order>();

        public IEnumerable<Model.Order> GetAll()
        {
            return list;
        }
    }
}
