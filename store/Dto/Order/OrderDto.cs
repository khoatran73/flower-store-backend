namespace store.Dto.Order;

public class OrderDto
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
}