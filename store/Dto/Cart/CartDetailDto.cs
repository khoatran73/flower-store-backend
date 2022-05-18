using store.Dto.Product;

namespace store.Dto.Cart;

public class CartDetailDto
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public int? Price { get; set; }
    public int? Total { get; set; }
    public virtual CartDto Cart { get; set; } = null!;
    public virtual ProductDto Product { get; set; } = null!;
}