using AutoMapper;
using store.Dto.Product;
using store.Entities;

namespace store.Services;

public class ProductService : IProductService
{
    private readonly henrystoreContext _context;
    private readonly IMapper _mapper;

    public ProductService(henrystoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> GetList()
    {
        var productDtos = _context.Products.Select(x => _mapper.Map<Product, ProductDto>(x)).ToList();

        return new List<ProductDto>(productDtos);
    }

    public async Task<ProductDto> Create(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<ProductCreateDto, Product>(productCreateDto);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<Product, ProductDto>(product);
    }
}