using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class CartDetail
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int? Price { get; set; }
        public int? Total { get; set; }
        public Guid Rowguid { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
