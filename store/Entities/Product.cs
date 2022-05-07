using System;
using System.Collections.Generic;

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

        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Name { get; set; }
        public int? UnitPrice { get; set; }
        public string? Image { get; set; }
        public int? TotalQuantity { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ProductCategory? Category { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductInStore> ProductInStores { get; set; }
    }
}
