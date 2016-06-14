using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ProductRepository
    {
        private static ICollection<Model.Product> list = new List<Model.Product>();

        public IEnumerable<Model.Product> GetAll()
        {
            return list;
        }
    }
}
