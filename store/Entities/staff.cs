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
        public Guid? StoreId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Salt { get; set; }
        public string? Role { get; set; }
        public string? Image { get; set; }
        public bool? IsActive { get; set; }
        public string? Fullname { get; set; }
        public bool? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Store? Store { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
