using store.Dto.Order;
using store.Dto.Product;

namespace store.Services;

public interface IOrderService
{
    Task<List<OrderDto>> Index(Guid? storeId);
    Task CreateOrder(OrderCreateDto createDto, Guid? storeId);
    Task<List<HistoryDto>> History(Guid customerId, CancellationToken cancellationToken = default);
}