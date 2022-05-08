using Microsoft.AspNetCore.Mvc;
using store.Api;
using store.Dto.Cart;
using store.Services;

namespace store.Controllers;

[ApiController]
[Route(@"api/cart")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet(@"")]
    public async Task<IActionResult> GetCart(Guid? accountId, Guid? id)
    {
        var cartDto = await _cartService.GetCart(accountId, id);

        return Ok(new ApiResponse<List<CartDto>>()
        {
            Success = true,
            Message = "",
            Result = cartDto
        });
    }

    [HttpPost(@"create-cart")]
    public async Task<IActionResult> CreateCart(CartCreateDto createDto)
    {
        var result = await _cartService.CreateCart(createDto);

        return Ok(new ApiResponse<CartDto>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }

    [HttpPost(@"create-cart-detail")]
    public async Task<IActionResult> CreateCartDetail(CartTotalCreateDto cartTotalCreateDto)
    {
        var cartDto = await _cartService.CreateCart(cartTotalCreateDto.CartCreateDto);
        cartTotalCreateDto.CartDetailCreateDto.CartId = cartDto.Id;
        var result = await _cartService.CreateCartDetail(cartTotalCreateDto.CartDetailCreateDto);
        await _cartService.UpdateTotalPrice(result.Cart);

        return Ok(new ApiResponse<CartDetailDto>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }

    [HttpDelete(@"remove-cart-detail")]
    public async Task<IActionResult> RemoveCartDetail(Guid cartId, Guid productId)
    {
        var result = await _cartService.RemoveCartDetail(cartId, productId);
        await _cartService.UpdateTotalPrice(result);

        return Ok(new ApiResponse<CartDto>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }
}