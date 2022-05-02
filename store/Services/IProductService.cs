using store.Dto.Product;

namespace store.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetList();
    Task<ProductDto> Get(string id);
    Task<ProductDto> Create(ProductCreateDto productCreateDto);
    Task Delete(string id);
}