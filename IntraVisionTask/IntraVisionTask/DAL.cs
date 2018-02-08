namespace IntraVisionTask
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DAL : DbContext
    {
        public DAL()
            : base("name=DAL")
        {
        }

        public virtual DbSet<CoinLoad> CoinLoads { get; set; }
        public virtual DbSet<CoinType> CoinTypes { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<OrderCoin> OrderCoins { get; set; }
        public virtual DbSet<OrderProd> OrderProds { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProdLoad> ProdLoads { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoinType>()
                .HasMany(e => e.CoinLoads)
                .WithRequired(e => e.CoinType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CoinType>()
                .HasMany(e => e.OrderCoins)
                .WithRequired(e => e.CoinType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Operation>()
                .HasMany(e => e.CoinLoads)
                .WithRequired(e => e.Operation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Operation>()
                .HasMany(e => e.ProdLoads)
                .WithRequired(e => e.Operation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderCoins)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderProds)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderProds)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProdLoads)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
