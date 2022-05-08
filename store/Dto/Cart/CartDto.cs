using store.Entities;

namespace store.Dto.Cart;

public class CartDto
{
    public Guid Id { get; set; }
    public Guid? AccountId { get; set; }
    public int? TotalPrice { get; set; }
    public virtual ICollection<CartDetailDto> CartDetails { get; set; }
}