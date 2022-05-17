using AutoMapper;
using store.Dto.Order;
using store.Entities;

namespace store.Mapper;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderCreateDto, Order>();
        CreateMap<Order, OrderDto>();

        CreateMap<Product, HistoryProduct>();
        CreateMap<CartDetail, HistoryCartDetail>();
        CreateMap<Cart, HistoryCart>();
        CreateMap<Order, HistoryDto>();
    }
    
}