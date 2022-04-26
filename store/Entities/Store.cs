using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
            ProductInStores = new HashSet<ProductInStore>();
            staff = new HashSet<staff>();
        }

        public string Id { get; set; } = null!;
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public Guid Rowguid { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<ProductInStore> ProductInStores { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
