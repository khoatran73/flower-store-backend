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

        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public int? TotalQuantity { get; set; }
        public int? TotalPrice { get; set; }
        public bool? IsDone { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
