using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class Comment
    {
        public Comment()
        {
            Reactions = new HashSet<Reaction>();
        }

        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? ProductId { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid Rowguid { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
    }
}
