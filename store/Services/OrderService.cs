using AutoMapper;
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

    public async Task<OrderDto> CreateOrder(OrderCreateDto createDto)
    {
        var order = _mapper.Map<OrderCreateDto, Order>(createDto);

        _context.Orders.Add(order);

        await _context.SaveChangesAsync();

        return _mapper.Map<Order, OrderDto>(order);
    }
}