using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using store.Dto.Product;
using store.Entities;

namespace store.Services;

public class ProductService : IProductService
{
    private readonly henrystoreContext _context;
    private readonly IMapper _mapper;
    private const int LimitRelatedProduct = 5;

    public ProductService(henrystoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> GetList(Guid? id, Guid? categoryId)
    {
        if (categoryId != null && id != null)
        {
            return await _context.Products
                .Where(x => x.CategoryId == categoryId)
                .Where(x => x.Id != id)
                .OrderByDescending(x => x.CreatedAt)
                .Take(LimitRelatedProduct)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        return await _context.Products
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<ProductDto> Get(Guid id)
    {
        var product = await _context.Products
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product == null) throw new Exception("Not found");

        return _mapper.Map<Product, ProductDto>(product);
    }


    public async Task<ProductDto> Create(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<ProductCreateDto, Product>(productCreateDto);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<Product, ProductDto>(product);
    }

    public async Task<ProductDto> Update(ProductUpdateDto updateDto, Guid id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product == null) throw new Exception("Not found");

        product.Name = updateDto.Name;

        if (updateDto.UnitPrice != null)
            product.UnitPrice = updateDto.UnitPrice;
        if (updateDto.CategoryId.HasValue)
            product.CategoryId = updateDto.CategoryId;
        if (updateDto.TotalQuantity != null)
            product.TotalQuantity = updateDto.TotalQuantity;
        if (updateDto.Description != null)
            product.Description = updateDto.Description;
        if (updateDto.Image != null)
            product.Image = updateDto.Image;

        await _context.SaveChangesAsync();
        return _mapper.Map<Product, ProductDto>(product);
    }

    public async Task Delete(Guid id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product == null) throw new Exception("Not found");

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CategoryDto>> ListCategory()
    {
        var categories = await _context.ProductCategories
            .Select(x => x)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return categories;
    }
}