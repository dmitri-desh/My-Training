using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orders
{
    public class OrderRow 
    {
        public int RowID { get; set; }
        public string RoomType { get; set; }
        public decimal RoomPrice { get; set; }
        public string ConsmrName { get; set; }
        public OrderRow (int rowID, string roomType, decimal roomPrice, string consmrName)
        {
            this.RowID = rowID;
            this.RoomType = roomType;
            this.ConsmrName = consmrName;
        }
    }
}