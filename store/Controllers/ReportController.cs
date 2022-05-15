using Microsoft.AspNetCore.Mvc;
using store.Api;
using store.Dto.Product;
using store.Services;

namespace store.Controllers;

[ApiController]
[Route(@"api/report")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
    
    [HttpGet(@"turnover")]
    public async Task<IActionResult> ListProductsSold()
    {
        var result = await _reportService.ListProductsSold();
        return Ok(new ApiResponse<List<ProductDto>>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }
    
    [HttpGet(@"test")]
    public async Task<IActionResult> Test()
    {
        await _reportService.Test();
        return Ok(new ApiResponse<bool>()
        {
            Success = true,
            Message = "",
        });
    }
}