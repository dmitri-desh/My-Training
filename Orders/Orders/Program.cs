using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderRow oRow = new OrderRow(1, "Room Type 1", 100, "Pupkin V.V.");
            
          
                Order o = new Order(1, "JSC Horns & Hooves", DateTime.Now, new List<OrderRow> { });
          
            o.PrintDoc(1);  // Print Invoice!
            o.PrintDoc(2);  // Print Wabill!
        }
    }
}
