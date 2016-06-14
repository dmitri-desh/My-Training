using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManagerRepository
    {
        private static ICollection<Model.ManagerSet> list = new List<Model.ManagerSet>();

        public IEnumerable<Model.ManagerSet> GetAll()
        {
            return list;
        }
    }
}
