using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManagerRepository
    {
        private static ICollection<Model.Manager> list = new List<Model.Manager>();

        public IEnumerable<Model.Manager> GetAll()
        {
            return list;
        }
    }
}
