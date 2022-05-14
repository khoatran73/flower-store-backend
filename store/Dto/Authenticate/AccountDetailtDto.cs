namespace store.Dto.Authenticate;

public class AccountDetailDto {
    public string Role { get; set; }
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }
    public string Image { get; set; }
}