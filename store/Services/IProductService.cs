using store.Dto.Product;

namespace store.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetList();
    Task<ProductDto> Create(ProductCreateDto productCreateDto);
}