using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Manager
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "Too many chars")]
        [StringLength(30, ErrorMessage = "Too many chars")]
        public string SecondName { get; set; }
        public virtual ICollection<Order> OrderSet { get; set; }
    }
}