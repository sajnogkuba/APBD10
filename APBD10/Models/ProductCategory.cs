using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Models;

[Table("Products_Categories")]
public class ProductCategory
{
    [Column("FK_product")]
    public int ProductId { get; set; }
    
    [Column("FK_category")]
    public int CategoryId { get; set; }
}