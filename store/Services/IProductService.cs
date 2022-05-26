using store.Dto.Product;

namespace store.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetList(Guid? id, string? categoryCode, Guid? storeId);
    Task<ProductDto> Get(Guid id);
    Task<ProductDto> Create(ProductCreateDto productCreateDto);
    Task<ProductDto> Update(ProductUpdateDto updateDto, Guid id);
    Task UpdateQuantity(Guid id, int quantity);
    Task Delete(Guid id);

    Task<List<CategoryDto>> ListCategory();
}