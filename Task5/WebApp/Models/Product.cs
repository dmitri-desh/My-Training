using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Too many chars")]
        [StringLength(100, ErrorMessage = "Too many chars")]
        public string Name { get; set; }
        public virtual ICollection<Order> OrderSet { get; set; }
    }
}