using store.Dto.Authenticate;

namespace store.Dto.Cart;

public class CartCreateDto
{
    public Guid? AccountId { get; set; }
    public int? TotalPrice { get; set; }
    public AccountDetailDto? Account { get; set; }
}