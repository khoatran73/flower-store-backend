using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class ProductInStore
    {
        public string ProductId { get; set; } = null!;
        public string StoreId { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid Rowguid { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
    }
}
