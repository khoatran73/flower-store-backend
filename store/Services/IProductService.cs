using store.Dto.Product;

namespace store.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetListAsync();
    Task<List<ProductDto>> GetListByCategoryCode(string? categoryCode, string? searchKey);
    Task<List<ProductDto>> GetListRelated(Guid id, string? categoryCode);
    Task<ProductDto> Get(Guid id);
    Task<ProductDto> Create(ProductCreateDto productCreateDto);
    Task<ProductDto> Update(ProductUpdateDto updateDto, Guid id);
    Task UpdateQuantity(Guid id, int quantity);
    Task Delete(Guid id);

    Task<List<CategoryDto>> ListCategory();
}