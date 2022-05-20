using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using store.Dto.Authenticate;
using store.Dto.User;
using store.Entities;

namespace store.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly henrystoreContext _context;
    private readonly IAuthenticateService _authenticateService;
    private IUserService _userServiceImplementation;

    public UserService(IMapper mapper, henrystoreContext context, IAuthenticateService authenticateService)
    {
        _mapper = mapper;
        _context = context;
        _authenticateService = authenticateService;
    }

    public async Task<List<UserDto>> ListStaff(Guid? storeId)
    {
        var db = SwapConnectionString.SwapDB(storeId);
        var userDtos = await db.staff
            // .Where(x => x.Role != "customer")
            .OrderBy(x => x.StoreId)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return userDtos;
    }

    public async Task<UserDto> GetCustomer(Guid accountId)
    {
        var userDto =  _context.Customers
            .Where(x => x.Id == accountId)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .Single();

        return userDto;
    }

    public async Task<Guid> GetCustomerId(Guid accountId)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == accountId);

        return customer.Id;
    }

    public async Task<List<UserDto>> ListCustomer(Guid? storeId)
    {
        var db = SwapConnectionString.SwapDB(storeId);
        return  await db.Customers
            // .Where(x => x.Role == "customer")
            .Select(x => x)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task UpdateCustomer(CustomerUpdateDto updateDto, Guid id)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

        if (customer == null) throw new Exception("customer null");

        customer.StoreId = updateDto.StoreId;
        customer.Gender = updateDto.Gender;
        customer.Fullname = updateDto.Fullname;
        customer.Address = updateDto.Address;
        customer.Phone = updateDto.Phone;
        customer.Email = updateDto.Email;
        customer.Birthday = updateDto.Birthday;

        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCustomerImage(string image, Guid? id)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
        if (customer == null) throw new Exception("customer null");

        customer.Image = image;
        await _context.SaveChangesAsync();
    }

   

}