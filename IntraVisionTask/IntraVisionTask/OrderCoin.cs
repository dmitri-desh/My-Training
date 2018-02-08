namespace IntraVisionTask
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
