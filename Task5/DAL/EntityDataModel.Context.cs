﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PurchasesAppEntities : DbContext
    {
        public PurchasesAppEntities()
            : base("name=PurchasesAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CustomerSet> CustomerSet { get; set; }
        public virtual DbSet<ManagerSet> ManagerSet { get; set; }
        public virtual DbSet<OrderSet> OrderSet { get; set; }
        public virtual DbSet<ProductSet> ProductSet { get; set; }
    }
}
