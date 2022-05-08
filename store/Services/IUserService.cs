using store.Dto.User;

namespace store.Services;

public interface IUserService
{
    Task CreateStaff(UserCreateDto createDto);
    Task<List<UserDto>> ListStaff();
    Task<UserDto> GetCustomer(Guid accountId);
    Task CreateCustomer(UserCreateDto createDto);
    Task<Guid> GetCustomerId(Guid accountId);
}