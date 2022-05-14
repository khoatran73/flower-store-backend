namespace store.Dto.Authenticate;

public class CustomerUpdateDto
{
    public Guid? StoreId { get; set; }
    public string? Fullname { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public bool? Gender { get; set; }
    public string? Email { get; set; }
    public DateTime? Birthday { get; set; }
    
    // storeId: storeId,
    // fullName: fullName,
    // gender: gender === 'true',
    // phone: phone,
    // email: email,
    // address: address,
    // birthday: birthday,
}