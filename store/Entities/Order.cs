using System;
using System.Collections.Generic;

namespace store.Entities
{
    public partial class Order
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? CartId { get; set; }
        public Guid? StaffId { get; set; }
        public double? Discount { get; set; }
        public int? Tax { get; set; }
        public int? TotalPrice { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? DeliveryAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid Rowguid { get; set; }

        public virtual Cart? Cart { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual staff? Staff { get; set; }
    }
}
