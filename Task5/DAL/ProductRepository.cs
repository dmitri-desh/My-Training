using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ProductRepository
    {
        private static ICollection<Model.ProductSet> list = new List<Model.ProductSet>();

        public IEnumerable<Model.ProductSet> GetAll()
        {
            return list;
        }
    }
}
