using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "Incorrect DataTime Item")]
        public DateTime PurchaseDate { get; set; }
        
        public decimal Amount { get; set; }
        public int ManagerId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public virtual Customer CustomerSet { get; set; }
        public virtual Manager ManagerSet { get; set; }
        public virtual Product ProductSet { get; set; }
    }
}