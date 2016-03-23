using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orders
{
    public class Order
    {
        public int OrderID { get; protected set; }
        public string ClientName { get; set; }

        public DateTime Created { get; set; }
        public List<OrderRow> OrderRows { get; set; }
        
        public void PrintDoc(int docType)
        {
            if (docType == 1)
            { 
                Console.WriteLine("Print", "Printing Invoice!");
            }
            else if (docType == 2)
            { 
                Console.WriteLine("Print", "Printing Waybill!");
            }
        }
        public Order (int orderID, string clientName, DateTime created, List<OrderRow> orderRows)
        {
            this.OrderID = orderID;
            this.ClientName = clientName;
            this.Created = created;
            this.OrderRows = orderRows;
         }
    }
}