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

        public string Id { get; set; } = null!;
        public string? AccountId { get; set; }
        public string? ProductId { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid Rowguid { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
    }
}
