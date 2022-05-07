using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using store.Dto.Authenticate;
using store.Entities;

namespace store.Services;

public class AuthenticateService : IAuthenticateService
{
    private readonly henrystoreContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<RegisterDto> _validator;
    private const int SizeSalt = 10;

    public AuthenticateService(henrystoreContext context, IMapper mapper, IValidator<RegisterDto> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    [Obsolete("Obsolete")]
    public async Task<bool> Register(RegisterDto registerDto)
    {
        var validate = await _validator.ValidateAsync(registerDto);
        var existAccount = _context.Accounts.FirstOrDefault(x => x.Username == registerDto.Username);

        if (!validate.IsValid || registerDto.Password != registerDto.ConfirmPassword || existAccount != null)
            return false;

        var salt = CreateSalt(SizeSalt);
        var passwordHash = CreateHashSha256(registerDto.Password, salt);
        var account = new Account()
        {
            Username = registerDto.Username,
            Salt = salt,
            PasswordHash = passwordHash,
            Role = "0",
            IsActive = false,
        };
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return true;

    }
    public async Task<List<AccountDto>> GetListAccount()
    {
        var accountDtos = await _context.Accounts
            .Select(x => x)
            .Where(x => x.Role != "customer")
            .ProjectTo<AccountDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        
        return accountDtos;
    }

    [Obsolete("Obsolete")]
    public async Task<AccountDto> CreateAccount(AccountCreateDto createDto)
    {
        // var validate = await _validator.ValidateAsync(createDto);
        var existAccount = _context.Accounts.FirstOrDefault(x => x.Username == createDto.Username);

        if (createDto.Password != createDto.ConfirmPassword || existAccount != null)
            throw new Exception("Error");
        
        
        var salt = CreateSalt(SizeSalt);
        var passwordHash = CreateHashSha256(createDto.Password, salt);

        var account = _mapper.Map<AccountCreateDto, Account>(createDto);
        account.Salt = salt;
        account.PasswordHash = passwordHash;

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return _mapper.Map<Account, AccountDto>(account);
    }

    [Obsolete("Obsolete")]
    public async Task<AccountDetailDto> Login(LoginDto loginDto)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Username == loginDto.Username);
        if (account == null) throw new Exception("Username sai");

        var hash = CreateHashSha256(loginDto.Password, account.Salt);

        if (hash == account.PasswordHash)
        {
            return _mapper.Map<Account, AccountDetailDto>(account);
        }

        throw new Exception("Sai mk");
    }


    [Obsolete("Obsolete")]
    private static string CreateSalt(int size)
    {
        var rng = new RNGCryptoServiceProvider();
        var buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }

    [Obsolete("Obsolete")]
    private static string CreateHashSha256(string password, string salt)
    {
        var bytes = Encoding.UTF8.GetBytes(password + salt);
        var hashString = new SHA256Managed();
        var hash = hashString.ComputeHash(bytes);
        return Convert.ToHexString(hash);
        // return ByteArrayToHexString(hash);
    }
}