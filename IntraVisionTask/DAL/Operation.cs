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
    
    public partial class Operation
    {
        public Operation()
        {
            this.CoinLoads = new HashSet<CoinLoad>();
            this.ProdLoads = new HashSet<ProdLoad>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public short Sign { get; set; }
    
        public virtual ICollection<CoinLoad> CoinLoads { get; set; }
        public virtual ICollection<ProdLoad> ProdLoads { get; set; }
    }
}
