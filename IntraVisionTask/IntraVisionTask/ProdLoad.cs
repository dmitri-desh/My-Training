namespace IntraVisionTask
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProdLoad
    {
        public int Id { get; set; }

        public short Cnt { get; set; }

        public int ProductId { get; set; }

        public int OperationId { get; set; }

        public DateTime Date { get; set; }

        public virtual Operation Operation { get; set; }

        public virtual Product Product { get; set; }
    }
}
