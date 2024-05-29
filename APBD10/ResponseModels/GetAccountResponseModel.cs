namespace APBD10.ResponseModels;

public class GetAccountResponseModel
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string? phone { get; set; }
    public string role { get; set; }
    public List<CartItem> cart { get; set; }
}

public class CartItem
{
    public int productId { get; set; }
    public string productName { get; set; }
    public int amount { get; set; }
}