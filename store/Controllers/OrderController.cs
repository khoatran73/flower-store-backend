using Microsoft.AspNetCore.Mvc;
using store.Api;
using store.Dto.Order;
using store.Services;

namespace store.Controllers;

[ApiController]
[Route(@"api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ICartService _cartService;

    public OrderController(IOrderService orderService, ICartService cartService)
    {
        _orderService = orderService;
        _cartService = cartService;
    }
    
    [HttpGet(@"")]
    public async Task<IActionResult> Index([FromQuery] Guid? storeId)
    {
        var result = await _orderService.Index(storeId);
        
        return Ok(new ApiResponse<List<OrderDto>>()
        {
            Success = true,
            Message = "",
            Result = result,
        });
    }

    [HttpPost(@"create")]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto createDto, [FromQuery] Guid? storeId)
    {
        await _cartService.SetDone(createDto.CartId);
        await _orderService.CreateOrder(createDto, storeId);
        
        return Ok(new ApiResponse<OrderDto>()
        {
            Success = true,
            Message = "",
        });
    }
    
    [HttpGet(@"history/{customerId:guid}")]
    public async Task<IActionResult> History([FromRoute] Guid customerId)
    {
        var result = await _orderService.History(customerId);
        
        return Ok(new ApiResponse<List<HistoryDto>>()
        {
            Success = true,
            Message = "",
            Result = result,
        });
    }
    
}