namespace store.Dto.Product;

public class ProductDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int UnitPrice { get; set; }
    public string Image { get; set; }
    public int Expiry { get; set; }
    public string? Description { get; set; }
    
}