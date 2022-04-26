using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; } = null!;
        public string AccountId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string StoreId { get; set; } = null!;
        public bool? MemberShip { get; set; }
        public Guid Rowguid { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
