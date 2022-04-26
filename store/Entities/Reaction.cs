using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class Reaction
    {
        public string AccountId { get; set; } = null!;
        public string CommentId { get; set; } = null!;
        public Guid Rowguid { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Comment Comment { get; set; } = null!;
    }
}
