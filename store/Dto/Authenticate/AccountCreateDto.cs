namespace store.Dto.Authenticate;

public class AccountCreateDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? Role { get; set; }
    public string? Image { get; set; }
    public bool? IsActive { get; set; }
    public string? Fullname { get; set; }
    public bool? Gender { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public DateTime? Birthday { get; set; }
    public IFormFile File { get; set; }
}