using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string BrandName { get; set; }

        public string GenericName { get; set; }

        public string Manufacturer { get; set; }

        [Required, StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string AffiliateURL { get; set; }

        public virtual ICollection<Price> Prices { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}