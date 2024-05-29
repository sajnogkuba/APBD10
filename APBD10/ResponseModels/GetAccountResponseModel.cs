namespace APBD10.ResponseModels;

public class GetAccountResponseModel
{
    public string AccountFirstName { get; set; }
    public string AccountLastName { get; set; }
    public string AccountEmail { get; set; }
    public string? AccountPhone { get; set; }
    public string RoleName { get; set; }
}

public class CartItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int ShoppingCartAmount { get; set; }
}