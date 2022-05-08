using store.Dto.Cart;
using store.Entities;

namespace store.Services;

public interface ICartService
{
    Task<CartDto> CreateCart(CartCreateDto createDto);
    Task<CartDetailDto> CreateCartDetail(CartDetailCreateDto createDto);
    Task UpdateTotalPrice(CartDto cartDto);
    Task<List<CartDto>> GetCart(Guid? accountId, Guid? id);
    Task<CartDto> RemoveCartDetail(Guid cartId, Guid productId);
    Task RemoveCart(Guid id);
    Task SetDone(Guid id);
}