//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderCoin
    {
        public int Id { get; set; }
        public int CoinTypeId { get; set; }
        public short Cnt { get; set; }
        public int OrderId { get; set; }
    
        public virtual CoinType CoinType { get; set; }
        public virtual Order Order { get; set; }
    }
}