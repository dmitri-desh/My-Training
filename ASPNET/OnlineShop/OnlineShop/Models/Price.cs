using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Price
    {
        [ScaffoldColumn(false)]
        public int PriceID { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        [Display(Name = "Quantity")]
        public string Quantity { get; set; }

        [Display(Name = "Dosage")]
        public string Dose { get; set; }

        [Display(Name = "Measure")]
        public string Measure { get; set; }
    }
}