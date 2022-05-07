using store.Dto.Authenticate;

namespace store.Dto.User;

public class UserCreateDto
{
    public Guid? StoreId { get; set; }
    public AccountCreateDto Account { get; set; }
}