using Microsoft.AspNetCore.Mvc;
using store.Api;
using store.Dto.Store;
using store.Services;

namespace store.Controllers;

[ApiController]
[Route(@"api/store")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;

    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet(@"")]
    public async Task<IActionResult> ListStore([FromQuery] Guid? storeId)
    {
        var result = await _storeService.ListStore(storeId);

        return Ok(new ApiResponse<List<StoreDto>>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }
}