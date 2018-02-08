using System.Data.Entity;


namespace OnlineShop.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("OnlineShop")
        {}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}