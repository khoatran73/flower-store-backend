using Microsoft.AspNetCore.Mvc;
using store.Api;
using store.Dto.Product;
using store.Services;

namespace store.Controllers;

[ApiController]
[Route(@"api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet(@"")]
    public async Task<IActionResult> Index()
    {
        var result = await _productService.GetList();
        return Ok(new ApiResponse<List<ProductDto>>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }
    
    [HttpPost(@"/create")]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto createDto)
    {
        var result = await _productService.Create(createDto);
        return Ok(new ApiResponse<ProductDto>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }
}