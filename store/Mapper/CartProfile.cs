using AutoMapper;
using store.Dto.Cart;
using store.Entities;

namespace store.Mapper;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<CartCreateDto, Cart>()
            .ForMember(x => x.CustomerId, opt =>
                opt.MapFrom(x => x.AccountId));
        CreateMap<CartDetailCreateDto, CartDetail>();
        CreateMap<Cart, CartDto>().ForMember(x => x.AccountId, opt => opt.MapFrom(x => x.CustomerId));
        CreateMap<CartDetail, CartDetailDto>();
    }
}