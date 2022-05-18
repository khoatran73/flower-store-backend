using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Dto.Cart;
using store.Entities;

namespace store.Services;

public class CartService : ICartService
{
    private readonly IMapper _mapper;
    private readonly henrystoreContext _context;
    private readonly IProductService _productService;

    public CartService(IMapper mapper, henrystoreContext context, IProductService productService)
    {
        _mapper = mapper;
        _context = context;
        _productService = productService;
    }

    public async Task<CartDto> CreateCart(CartCreateDto createDto)
    {
        var existCart = _context.Carts.FirstOrDefault(x => x.CustomerId == createDto.AccountId && x.IsDone != true);
        if (existCart != null) return _mapper.Map<Cart, CartDto>(existCart);
        // if (createDto.Account != null && createDto.Account.Role != "customer")
        //     throw new Exception("only customer can buy");

        var cart = _mapper.Map<CartCreateDto, Cart>(createDto);

        _context.Carts.Add(cart);

        await _context.SaveChangesAsync();

        return _mapper.Map<Cart, CartDto>(cart);
    }

    public async Task CreateCartDetail(CartDetailCreateDto createDto)
    {
        var cart = _context.Carts.FirstOrDefault(x => x.Id == createDto.CartId && x.IsDone != true);
        if (cart == null) throw new Exception("Cart null");

        var existCartDetail = _context.CartDetails
            .FirstOrDefault(x => x.CartId == createDto.CartId && x.ProductId == createDto.ProductId);

        if (existCartDetail != null)
        {
            await UpdateQuantityCartDetail(existCartDetail, createDto.Quantity, createDto.Price);
            await UpdateTotalPrice(cart.Id);
            return;
        }

        var cartDetail = _mapper.Map<CartDetailCreateDto, CartDetail>(createDto);
        cart.CartDetails.Add(cartDetail);
        await _context.SaveChangesAsync();
    }

    private async Task UpdateQuantityCartDetail(CartDetail cartDetail, int quantity, int? price)
    {
        cartDetail.Quantity = cartDetail.Quantity + quantity;
        cartDetail.Price = price + cartDetail.Price;

        await _context.SaveChangesAsync();

        // return _mapper.Map<CartDetail, CartDetailDto>(cartDetail);
    }

    public async Task UpdateTotalPrice(Guid cartId)
    {
        var cart = _context.Carts.Include(x => x.CartDetails)
            .FirstOrDefault(x => x.Id == cartId && x.IsDone != true);
        if (cart == null) throw new Exception("Cart null");


        var cartDetails = cart.CartDetails;

        int? totalPrice = 0;
        foreach (var cartDetail in cartDetails)
        {
            totalPrice = totalPrice + cartDetail.Price;
        }

        cart.TotalPrice = totalPrice;
        await _context.SaveChangesAsync();
    }

    public async Task<List<CartDto>> GetCart(Guid? accountId, Guid? id)
    {
        if (accountId.HasValue)
        {
            var carts = await _context.Carts
                .Where(x => x.CustomerId == accountId && x.IsDone != true)
                .ProjectTo<CartDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return carts;
        }
        else
        {
            var carts = await _context.Carts
                .Where(x => x.Id == id && x.IsDone != true)
                .ProjectTo<CartDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return carts;
        }
    }

    public async Task RemoveCartDetail(Guid cartId, Guid productId)
    {
        var cart = _context.Carts
            .Where(x => x.Id == cartId && x.IsDone != true)
            .Include(x => x.CartDetails)
            .Single();
        if (cart == null) throw new Exception("Cart null");

        var cartDetail = cart.CartDetails
            .FirstOrDefault(x => x.CartId == cartId && x.ProductId == productId);

        if (cartDetail == null) throw new Exception("Cart Detail null");

        cart.CartDetails.Remove(cartDetail);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveCart(Guid id)
    {
        var cart = _context.Carts.FirstOrDefault(x => x.Id == id);
        if (cart == null) throw new NotImplementedException();

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync();
    }

    public async Task SetDone(Guid id)
    {
        var cart = await _context.Carts
            .Include(x => x.CartDetails)
            .FirstOrDefaultAsync(x => x.Id == id && x.IsDone != true);

        if (cart == null) throw new Exception("err");

        var cartDetails = cart.CartDetails;
        foreach (var cartDetail in cartDetails)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == cartDetail.ProductId);
            if (product != null && (product.TotalQuantity - cartDetail.Quantity > 0))
            {
                product.TotalQuantity = product.TotalQuantity - cartDetail.Quantity;
                _context.Products.Update(product);
            }
            else
            {
                throw new Exception("err");
            }
        }

        cart.IsDone = true;

        await _context.SaveChangesAsync();
    }
}