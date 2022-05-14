using store.Dto.User;

namespace store.Services;

public interface IUserService
{
    Task<List<UserDto>> ListStaff(Guid? storeId);
    Task<UserDto> GetCustomer(Guid accountId);
    Task CreateCustomer(UserCreateDto createDto);
    Task<Guid> GetCustomerId(Guid accountId);
    Task<List<UserDto>> ListCustomer();
}