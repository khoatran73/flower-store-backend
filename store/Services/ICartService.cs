using store.Dto.Cart;
using store.Entities;

namespace store.Services;

public interface ICartService
{
    Task<CartDto> CreateCart(CartCreateDto createDto);
    Task CreateCartDetail(CartDetailCreateDto createDto);
    Task UpdateTotalPrice(Guid cartId);
    Task<List<CartDto>> GetCart(Guid? accountId, Guid? id);
    Task RemoveCartDetail(Guid cartId, Guid productId);
    Task RemoveCart(Guid id);
    Task SetDone(Guid id, CancellationToken cancellationToken = default);
    Task UpdateProductQuantity(Guid cartId);
}