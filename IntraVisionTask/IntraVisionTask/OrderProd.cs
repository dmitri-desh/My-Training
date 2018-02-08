namespace IntraVisionTask
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderProd
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public short Cnt { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
