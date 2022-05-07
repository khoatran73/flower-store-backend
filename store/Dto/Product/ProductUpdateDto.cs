namespace store.Dto.Product;

public class ProductUpdateDto
{
    public string? Name { get; set; }
    public Guid? CategoryId { get; set; }
    public int? UnitPrice { get; set; }
    public string? Image { get; set; }
    public int? TotalQuantity { get; set; }
    public string? Description { get; set; }
    public IFormFile? File { get; set; }
}