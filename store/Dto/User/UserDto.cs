using store.Dto.Authenticate;
using store.Dto.Store;

namespace store.Dto.User;

public class UserDto
{
    // public Guid StoreId { get; set; }
    public AccountDto Account { get; set; }
    public StoreDto Store { get; set; }
}