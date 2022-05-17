using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using store.Dto.Order;
using store.Entities;

namespace store.Services;

public class OrderService : IOrderService
{
    private readonly henrystoreContext _context;
    private readonly IMapper _mapper;

    public OrderService(henrystoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> Index(Guid? storeId)
    {
        var db = SwapConnectionString.SwapDB(storeId);
        return await db.Orders
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task CreateOrder(OrderCreateDto createDto, Guid? storeId)
    {
        var order = _mapper.Map<OrderCreateDto, Order>(createDto);

        _context.Orders.Add(order);

        await _context.SaveChangesAsync();
    }

    public async Task<List<HistoryDto>> History(Guid customerId, CancellationToken cancellationToken = default)
    {
        var listOrders = await _context.Orders
            .Where(x => x.CustomerId == customerId)
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<HistoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);

        return listOrders;
    }
}