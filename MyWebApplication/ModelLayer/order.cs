//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
        public Nullable<int> managerid { get; set; }
        public Nullable<int> customerid { get; set; }
        public Nullable<int> productid { get; set; }
        public Nullable<System.DateTime> purchasedate { get; set; }
    }
}
