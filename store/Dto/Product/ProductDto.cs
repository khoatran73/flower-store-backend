namespace store.Dto.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid? CategoryId { get; set; }
    public int? UnitPrice { get; set; }
    public string? Image { get; set; }
    public int? TotalQuantity { get; set; }
    public string? Description { get; set; }
    public CategoryDto? Category { get; set; }
}