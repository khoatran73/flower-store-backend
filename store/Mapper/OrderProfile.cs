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
    }
    
}