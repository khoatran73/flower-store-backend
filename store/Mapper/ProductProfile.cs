using AutoMapper;
using store.Dto.Product;
using store.Entities;

namespace store.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductCreateDto, Product>();
    }
}