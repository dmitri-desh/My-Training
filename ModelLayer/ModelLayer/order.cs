//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class order
    {
        public int id { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<System.DateTime> purchasedate { get; set; }
        public int productid { get; set; }
        public int customerid { get; set; }
        public int managerid { get; set; }
    
        public virtual product Product { get; set; }
        public virtual customer Customer { get; set; }
        public virtual manager Manager { get; set; }
    }
}