using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class Comment
    {
        public Comment()
        {
            Accounts = new HashSet<Account>();
        }

        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? ProductId { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Product? Product { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
