using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class Account
    {
        public Account()
        {
            Carts = new HashSet<Cart>();
            Comments = new HashSet<Comment>();
            Customers = new HashSet<Customer>();
            Reactions = new HashSet<Reaction>();
            staff = new HashSet<staff>();
        }

        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public Guid Rowguid { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
