using AutoMapper;
using store.Dto.Cart;
using store.Entities;

namespace store.Mapper;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<CartCreateDto, Cart>()
            .ForMember(x => x.Account, opt => 
                opt.Ignore());
        CreateMap<CartDetailCreateDto, CartDetail>();
        CreateMap<Cart, CartDto>();
        CreateMap<CartDetail, CartDetailDto>();
    }
}