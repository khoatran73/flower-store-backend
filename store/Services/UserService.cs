using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using store.Dto.User;
using store.Entities;

namespace store.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly henrystoreContext _context;
    private readonly IAuthenticateService _authenticateService;

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

    public Task CreateCustomer(UserCreateDto createDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> GetCustomerId(Guid accountId)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == accountId);

        return customer.Id;
    }

    public async Task<List<UserDto>> ListCustomer()
    {
        return  await _context.Customers
            // .Where(x => x.Role == "customer")
            .Select(x => x)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    // public async Task UpdateCustomer(UserCreateDto createDto)
    // {
    //     var account = _context.Accounts.FirstOrDefault(x => x.Id == createDto.Account.);
    //         // _authenticateService.CreateAccount(createDto.Account);
    //     var customer = new Customer
    //     {
    //         AccountId = account.Id,
    //         StoreId = createDto.StoreId,
    //     };
    //
    //     _context.Customers.Add(customer);
    //     await _context.SaveChangesAsync();
    // }
}