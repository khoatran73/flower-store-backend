using store.Dto.Product;

namespace store.Services;

public interface IReportService
{
    Task<List<ProductDto>> ListProductsSold();

    Task Test();
}