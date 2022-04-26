using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class Order
    {
        public string Id { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string CartId { get; set; } = null!;
        public string StaffId { get; set; } = null!;
        public double? Discount { get; set; }
        public int? Tax { get; set; }
        public int? TotalPrice { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? DeliveryDate { get; set; }
        public TimeSpan? DeliveryTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid Rowguid { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual staff Staff { get; set; } = null!;
    }
}
