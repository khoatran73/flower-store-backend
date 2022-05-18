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
    private readonly ICloudinaryService _cloudinaryService;

    public ProductController(IProductService productService, IFileService fileService, ICloudinaryService cloudinaryService)
    {
        _productService = productService;
        _fileService = fileService;
        _cloudinaryService = cloudinaryService;
    }

    [HttpGet(@"")]
    public async Task<IActionResult> Index([FromQuery] Guid? id, Guid? categoryId, Guid? storeId)
    {
        var result = await _productService.GetList(id, categoryId, storeId);
        return Ok(new ApiResponse<List<ProductDto>>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }

    [HttpGet(@"{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
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
        var imageUploadResult = await _cloudinaryService.UploadImage(filePath, "Flower-store");
        var image = imageUploadResult.Url.ToString();
        createDto.Image = image;
        var result = await _productService.Create(createDto);

        return Ok(new ApiResponse<ProductDto>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }

    [HttpDelete(@"delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
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

    [HttpPost(@"update/{id:guid}")]
    public async Task<IActionResult> Update([FromForm] ProductUpdateDto updateDto, [FromRoute] Guid id)
    {
        if (updateDto.File != null)
        {
            var filePath = await _fileService.UploadFile(updateDto.File, "Uploads/product");
            var imageUploadResult = await _cloudinaryService.UploadImage(filePath, "Flower-store");
            var image = imageUploadResult.Url.ToString();
            updateDto.Image = image;
        }

        var result = await _productService.Update(updateDto, id);

        return Ok(new ApiResponse<ProductDto>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }

    [HttpGet(@"categories")]
    public async Task<IActionResult> ListCategory()
    {
        var result = await _productService.ListCategory();
        return Ok(new ApiResponse<List<CategoryDto>>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }
}