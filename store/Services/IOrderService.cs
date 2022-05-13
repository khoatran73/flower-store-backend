using store.Dto.Order;

namespace store.Services;

public interface IOrderService
{
    Task<List<OrderDto>> Index();
    Task CreateOrder(OrderCreateDto createDto);
}