using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class CustomerRepository
    {
        private static ICollection<Model.Customer> list = new List<Model.Customer>();

        public IEnumerable<Model.Customer> GetAll()
        {
            return list;
        }
    }
}
