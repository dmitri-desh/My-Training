using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string SecondName { get; set; }
        public virtual ICollection<Order> OrderSet { get; set; }
    }
}