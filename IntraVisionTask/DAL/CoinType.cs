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
    
    public partial class CoinType
    {
        public CoinType()
        {
            this.CoinLoads = new HashSet<CoinLoad>();
            this.OrderCoins = new HashSet<OrderCoin>();
        }
    
        public int Id { get; set; }
        public short Dignity { get; set; }
    
        public virtual ICollection<CoinLoad> CoinLoads { get; set; }
        public virtual ICollection<OrderCoin> OrderCoins { get; set; }
    }
}