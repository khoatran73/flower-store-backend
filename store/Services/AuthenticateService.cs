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
        var existAccount = _context.Customers.FirstOrDefault(x => x.Username == registerDto.Username);

        if (!validate.IsValid || registerDto.Password != registerDto.ConfirmPassword || existAccount != null)
            return false;

        var salt = CreateSalt(SizeSalt);
        var passwordHash = CreateHashSha256(registerDto.Password, salt);
        var customer = new Customer()
        {
            Username = registerDto.Username,
            Salt = salt,
            PasswordHash = passwordHash,
            Role = "customer",
        };
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return true;

    }
    // public async Task<List<AccountDto>> GetListAccount()
    // {
    //     var accountDtos = await _context.Accounts
    //         .Select(x => x)
    //         .Where(x => x.Role != "customer")
    //         .ProjectTo<AccountDto>(_mapper.ConfigurationProvider)
    //         .ToListAsync();
    //     
    //     return accountDtos;
    // }

    [Obsolete("Obsolete")]
    public async Task<AccountDto> CreateAccount(AccountCreateDto createDto, Guid? storeId)
    {
        // var validate = await _validator.ValidateAsync(createDto);
        var existAccount = _context.staff.FirstOrDefault(x => x.Username == createDto.Username);
    
        if (createDto.Password != createDto.ConfirmPassword || existAccount != null)
            throw new Exception("Error");
        
        
        var salt = CreateSalt(SizeSalt);
        var passwordHash = CreateHashSha256(createDto.Password, salt);
    
        var staff = _mapper.Map<AccountCreateDto, staff>(createDto);
        staff.Salt = salt;
        staff.PasswordHash = passwordHash;
        staff.StoreId = storeId;
        
        _context.staff.Add(staff);
        await _context.SaveChangesAsync();
    
        return _mapper.Map<staff, AccountDto>(staff);
    }

    public async Task UpdateAccount(AccountUpdateDto updateDto)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == updateDto.Id);
        customer.Fullname = updateDto.Fullname;
        customer.Address = updateDto.Address;
        customer.Phone = updateDto.Phone;
        customer.Email = updateDto.Email;

        await _context.SaveChangesAsync();
    }

    public async Task<AccountDto> GetAccount(Guid id)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

        if (customer != null)
        {
            return _mapper.Map<Customer, AccountDto>(customer);
            
        }

        var staff = _context.staff.FirstOrDefault(x => x.Id == id);

        if (staff != null)
        {
            return _mapper.Map<staff, AccountDto>(staff);

        }

        throw new Exception("no account");
    }

    [Obsolete("Obsolete")]
    public async Task<AccountDetailDto> Login(LoginDto loginDto, Guid? storeId)
    {
        // var context = _context;
        if (string.Equals(storeId.ToString(), "AEABAAAD-9B84-4E09-BCC2-1FF599F3B760", StringComparison.CurrentCultureIgnoreCase))
        {
            var selectedDb = new henrystoreContext();
            
            selectedDb.ChangeDatabase
            (
               "Data Source=KHOA-PRO\\TRAM1;Initial Catalog=henrystore;User ID=sa;Password=123456"
            );
            
            var customer = await selectedDb.Customers.FirstOrDefaultAsync(x => x.Username == loginDto.Username);
            var staff = await selectedDb.staff.FirstOrDefaultAsync(x => x.Username == loginDto.Username);
            if (customer == null && staff == null) throw new Exception("Username sai");

            // var hash = ;

            if (customer != null && CreateHashSha256(loginDto.Password, customer.Salt) == customer.PasswordHash)
            {
                return _mapper.Map<Customer, AccountDetailDto>(customer);
            } 
            if (staff != null &&  CreateHashSha256(loginDto.Password, staff.Salt) == staff.PasswordHash)
            {
                return _mapper.Map<staff, AccountDetailDto>(staff);
            }
        }
        
        var cus = await _context.Customers.FirstOrDefaultAsync(x => x.Username == loginDto.Username);
        var sta = await _context.staff.FirstOrDefaultAsync(x => x.Username == loginDto.Username);
        if (cus == null && sta == null) throw new Exception("Username sai");

        // var hash = ;

        if (cus != null && CreateHashSha256(loginDto.Password, cus.Salt) == cus.PasswordHash)
        {
            return _mapper.Map<Customer, AccountDetailDto>(cus);
        } 
        if (sta != null &&  CreateHashSha256(loginDto.Password, sta.Salt) == sta.PasswordHash)
        {
            return _mapper.Map<staff, AccountDetailDto>(sta);
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