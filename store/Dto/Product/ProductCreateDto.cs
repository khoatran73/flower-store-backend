namespace store.Dto.Product;

public class ProductCreateDto
{
    public string Name { get; set; }
    public int UnitPrice { get; set; }
    public string? Image { get; set; }
    public int Expiry { get; set; }
    public string? Description { get; set; }
    public IFormFile File { get; set; }
}