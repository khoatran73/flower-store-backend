using store.Dto.Authenticate;
using store.Entities;

namespace store.Services;

public interface IAuthenticateService
{
    Task<bool> Register(RegisterDto registerDto);
    Task<AccountDetailDto> Login(LoginDto loginDto, Guid? storeId);
    // Task<List<AccountDto>> GetListAccount();
    Task<AccountDto> CreateAccount(AccountCreateDto createDto, Guid? storeId);
    Task UpdateAccount(AccountUpdateDto updateDto);
    Task<AccountDto> GetAccount(Guid id);
}