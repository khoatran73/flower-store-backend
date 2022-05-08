using store.Dto.Order;

namespace store.Services;

public interface IOrderService
{
    Task<List<OrderDto>> Index();
    Task<OrderDto> CreateOrder(OrderCreateDto createDto);
}