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
    
    public partial class manager
    {
        public manager()
        {
            this.Orders = new HashSet<order>();
        }
    
        public int id { get; set; }
        public string secondname { get; set; }
    
        public virtual ICollection<order> Orders { get; set; }
    }
}
