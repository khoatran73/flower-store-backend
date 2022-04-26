using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class User
    {
        public User()
        {
            Customers = new HashSet<Customer>();
            staff = new HashSet<staff>();
        }

        public string Id { get; set; } = null!;
        public string? Fullname { get; set; }
        public bool? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthday { get; set; }
        public Guid Rowguid { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
