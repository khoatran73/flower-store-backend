using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class ProductInStore
    {
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public int Quantity { get; set; }
        public Guid Rowguid { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
    }
}
