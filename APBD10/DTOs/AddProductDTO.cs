namespace APBD10.DTOs;

public record AddProductDTO
{
    public string productName { get; set; }
    public double productWeight { get; set; }
    public double productHeight { get; set; }
    public double productDepth { get; set; }
    public List<int> productCategories { get; set; }
}