using System;
using System.Collections.Generic;
using store.Repositories.Core;

namespace store.Entities
{
    public partial class Product
    {
        public Product()
        {
            CartDetails = new HashSet<CartDetail>();
            Comments = new HashSet<Comment>();
            ProductInStores = new HashSet<ProductInStore>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int UnitPrice { get; set; }
        public string Image { get; set; } = null!;
        public int Expiry { get; set; }
        public string? Description { get; set; }
        public Guid Rowguid { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductInStore> ProductInStores { get; set; }
    }
}
