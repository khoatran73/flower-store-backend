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

    public async Task CreateStaff(UserCreateDto createDto)
    {
        var account = await _authenticateService.CreateAccount(createDto.Account);
        var staff = new staff
        {
            AccountId = account.Id,
            StoreId = createDto.StoreId,
        };

        _context.staff.Add(staff);
        await _context.SaveChangesAsync();
    }

    public async Task<List<UserDto>> ListStaff()
    {
        var userDtos = await _context.staff.Select(x => x)
            .Select(x => x)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return userDtos;
    }
}