using store.Dto.Order;

namespace store.Services;

public interface IOrderService
{
    Task<OrderDto> CreateOrder(OrderCreateDto createDto);
}