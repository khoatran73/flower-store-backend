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
    private readonly IFileService _fileService;

    public ProductController(IProductService productService, IFileService fileService)
    {
        _productService = productService;
        _fileService = fileService;
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
    
    [HttpGet(@"{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var result = await _productService.Get(id);
        return Ok(new ApiResponse<ProductDto>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }
    
    [HttpPost(@"create")]
    public async Task<IActionResult> Create([FromForm] ProductCreateDto createDto)
    {
        var filePath = await _fileService.UploadFile(createDto.File, "Uploads/product");
        createDto.Image = filePath;
        var result = await _productService.Create(createDto);
        
        return Ok(new ApiResponse<ProductDto>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }
    
    [HttpDelete(@"delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        try
        {
            await _productService.Delete(id);
            return Ok(new ApiResponse<ProductDto>()
            {
                Success = true,
                Message = "",
            });
        }
        catch 
        {
            throw new Exception("Some Error");
        }
    }
}