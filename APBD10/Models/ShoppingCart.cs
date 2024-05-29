using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Models;

[Table("Shopping_Carts")]
public class ShoppingCart
{
    [Column("FK_account")]
    public int AccountID { get; set; }
    
    [Column("FK_product")]
    public int ProductID { get; set; }
    
    [Column("amount")]
    public int ShoppingCartAmount { get; set; }
}