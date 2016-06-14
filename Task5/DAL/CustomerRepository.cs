using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class CustomerRepository
    {
        private static ICollection<Model.CustomerSet> list = new List<Model.CustomerSet>();

        public IEnumerable<Model.CustomerSet> GetAll()
        {
            return list;
        }
    }
}
