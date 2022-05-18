using store.Dto.Cart;
using store.Dto.Product;

namespace store.Dto.Order;

public class HistoryDto
{
    public Guid Id { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? CartId { get; set; }
    public double? Discount { get; set; }
    public int? Tax { get; set; }
    public int? TotalPrice { get; set; }
    public DateTime? DeliveryAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public virtual HistoryCart Cart { get; set; }
}

public class HistoryCart
{
    public Guid Id { get; set; }
    public ICollection<HistoryCartDetail> CartDetails { get; set; }
}

public class HistoryCartDetail
{
    public int? Quantity { get; set; }
    public int? Price { get; set; }
    public ProductDto Product { get; set; }
}

public class HistoryProduct
{
    public string? Name { get; set; }
}