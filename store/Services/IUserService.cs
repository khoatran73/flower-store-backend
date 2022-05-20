using store.Dto.Authenticate;
using store.Dto.User;

namespace store.Services;

public interface IUserService
{
    Task<List<UserDto>> ListStaff(Guid? storeId);
    Task<UserDto> GetCustomer(Guid accountId);
    Task<Guid> GetCustomerId(Guid accountId);
    Task<List<UserDto>> ListCustomer(Guid? storeId);
    Task UpdateCustomer(CustomerUpdateDto updateDto, Guid id);

    Task UpdateCustomerImage(string image, Guid? id);

    
}