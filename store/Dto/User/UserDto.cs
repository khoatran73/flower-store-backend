using store.Dto.Authenticate;
using store.Dto.Store;

namespace store.Dto.User;

public class UserDto : AccountDto
{
    // public Guid StoreId { get; set; }
    // public  Account { get; set; }
    public StoreDto Store { get; set; }
}