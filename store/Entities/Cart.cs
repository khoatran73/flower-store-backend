using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            CartDetails = new HashSet<CartDetail>();
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; } = null!;
        public string AccountId { get; set; } = null!;
        public int TotalQuantity { get; set; }
        public int TotalPrice { get; set; }
        public Guid Rowguid { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
