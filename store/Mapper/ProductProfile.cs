using AutoMapper;
using store.Dto.Product;
using store.Entities;

namespace store.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // CreateMap<Product, ProductDto>().ForMember(x => x.Image, opt 
        // => opt.MapFrom(x => Path.GetFullPath(x.Image)));
        CreateMap<Product, ProductDto>();
        CreateMap<ProductCreateDto, Product>();
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<ProductCategory, CategoryDto>();
    }
}