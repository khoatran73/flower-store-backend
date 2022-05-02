using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        var productDtos = await _context.Products
            .Select(x => _mapper.Map<Product, ProductDto>(x)).ToListAsync();

        return new List<ProductDto>(productDtos);
    }

    public async Task<ProductDto> Get(string id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product == null) throw new Exception("Not found");

        return _mapper.Map<Product, ProductDto>(product);
    }


    public async Task<ProductDto> Create(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<ProductCreateDto, Product>(productCreateDto);
        product.Id = Guid.NewGuid().ToString();
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<Product, ProductDto>(product);
    }

    public async Task Delete(string id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product == null) throw new Exception("Not found");
        
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}