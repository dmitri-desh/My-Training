using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class WebAppContext : DbContext
    {
        public WebAppContext() : base("PurchasesAppEntities")
        {
        }

        public DbSet<ManagerSet> ManagerSet { get; set; }
        public DbSet<OrderSet> OrderSet { get; set; }
    //    public DbSet<vOrders> vOrders { get; set; }
        public DbSet<CustomerSet> CustomerSet { get; set; }
        public DbSet<ProductSet> ProductSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
