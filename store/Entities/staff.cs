using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class staff
    {
        public staff()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? StoreId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Store? Store { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
