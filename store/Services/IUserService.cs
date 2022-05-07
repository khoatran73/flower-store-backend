using store.Dto.User;

namespace store.Services;

public interface IUserService
{
    Task CreateStaff(UserCreateDto createDto);
    Task<List<UserDto>> ListStaff();
}