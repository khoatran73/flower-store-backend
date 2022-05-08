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

    [HttpPost(@"create")]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto createDto)
    {
        await _cartService.SetDone(createDto.CartId);
        var result = await _orderService.CreateOrder(createDto);
        
        return Ok(new ApiResponse<OrderDto>()
        {
            Success = true,
            Message = "",
            Result = result,
        });
    }
    
}