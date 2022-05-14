using store.Dto.Order;

namespace store.Services;

public interface IOrderService
{
    Task<List<OrderDto>> Index(Guid? storeId);
    Task CreateOrder(OrderCreateDto createDto, Guid? storeId);
}