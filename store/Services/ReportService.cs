using System.Globalization;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using store.Dto.Product;
using store.Entities;

namespace store.Services;

public class ReportService : IReportService
{
    private readonly IMapper _mapper;
    private readonly henrystoreContext _context;
    
    public ReportService(IMapper mapper, henrystoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<ProductDto>> ListProductsSold()
    {
        var products = _context.Products
            .Include(x => x.Category)
            .Include(x => x.CartDetails)
            .ThenInclude(y => y.Cart)
            .ThenInclude(z => z.Orders)
            .Where(x => x.CartDetails.Any())
            .ToList();

        var productDtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var countSold = 0;
            foreach (var productCartDetail in product.CartDetails)
            {
                if (productCartDetail.Cart.IsDone == true)
                {
                    countSold = countSold + productCartDetail.Quantity;
                }
            }

            var productDto = _mapper.Map<Product, ProductDto>(product);
            productDto.CountSold = countSold;
            productDtos.Add(productDto);
        }


        // var productDtos = _mapper.Map<List<Product>, List<ProductDto>>(products);

        return productDtos;
    }

    public async Task Test()
    {
        var dt = DateTime.ParseExact("2022-05-14 22:19:18.403", "yyyy/MM/DD", CultureInfo.InvariantCulture);
            
        var customers = _context.Customers
            .GroupBy(x =>  x.CreatedAt)
            .Select(x => new
            {
                Value = x.Count(),
                // Replace the commented line
                //Day = (DateTime)DbFunctions.TruncateTime(x.Key)
                // ...with this line
                Day = (DateTime)x.Key
            }).ToList();
        
        throw new NotImplementedException();
    }
}