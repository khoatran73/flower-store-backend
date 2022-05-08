namespace store.Dto.Order;

public class OrderCreateDto
{
    public Guid? CustomerId { get; set; }
    public Guid CartId { get; set; }
    public Guid? StaffId { get; set; }
    public int? TotalPrice { get; set; }
    public string? Description { get; set; }
}