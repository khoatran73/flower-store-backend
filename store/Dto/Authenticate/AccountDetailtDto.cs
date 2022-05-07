namespace store.Dto.Authenticate;

public class AccountDetailDto {
    public string Role { get; set; } = null!;
    public string? Image { get; set; }
    public bool IsActive { get; set; }
    public string? Username { get; set; }
}