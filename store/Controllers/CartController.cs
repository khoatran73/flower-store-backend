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
        await _cartService.CreateCartDetail(cartTotalCreateDto.CartDetailCreateDto);
        await _cartService.UpdateTotalPrice(cartDto.Id);

        return Ok(new ApiResponse<bool>()
        {
            Success = true,
            Message = "",
        });
    }

    [HttpDelete(@"remove-cart-detail")]
    public async Task<IActionResult> RemoveCartDetail(Guid cartId, Guid productId)
    {
        await _cartService.RemoveCartDetail(cartId, productId);
        await _cartService.UpdateTotalPrice(cartId);

        return Ok(new ApiResponse<CartDto>()
        {
            Success = true,
            Message = "",
        });
    }
}