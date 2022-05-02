using Microsoft.AspNetCore.Mvc;
using store.Api;
using store.Dto.File;
using store.Services;

namespace store.Controllers;

[ApiController]
[Route(@"api/upload-file")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly IHostEnvironment _hostingEnvironment;

    public FileController(IFileService fileService, IHostEnvironment hostingEnvironment)
    {
        _fileService = fileService;
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpPost(@"upload")]
    public async Task<IActionResult> CreateFile(IFormFile fileUpload)
    {
        var filePath = await _fileService.UploadFile(fileUpload, "Uploads/product");

        return Ok(new ApiResponse<string>()
        {
            Success = true,
            Message = "",
            Result = filePath
        });
    }
}