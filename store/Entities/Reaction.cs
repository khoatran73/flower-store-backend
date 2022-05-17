using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class Reaction
    {
        public Guid CustomerId { get; set; }
        public Guid CommentId { get; set; }
        public Guid Rowguid { get; set; }

        public virtual Comment Comment { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}
