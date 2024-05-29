namespace APBD10.DTOs;

public record AddProductDTO
{
    public string productName { get; set; }
    public decimal productWeight { get; set; }
    public decimal productHeight { get; set; }
    public decimal productDepth { get; set; }
    public List<int> productCategories { get; set; }
}