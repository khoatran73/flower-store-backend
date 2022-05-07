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
            staff = new HashSet<staff>();
            CommentsNavigation = new HashSet<Comment>();
        }

        public Guid Id { get; set; }
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

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<staff> staff { get; set; }

        public virtual ICollection<Comment> CommentsNavigation { get; set; }
    }
}
