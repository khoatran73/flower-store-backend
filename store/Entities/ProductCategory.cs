using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
