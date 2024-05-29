using APBD10.Contexts;
using APBD10.Exceptions;
using APBD10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Services;

public interface IAccountService
{
    Task<GetAccountResponseModel> GetAccountAsync(int accountId);
}

public class AccountService(DatabaseContext context) : IAccountService
{
    public async Task<GetAccountResponseModel> GetAccountAsync(int accountId)
    {
        var response = await context.Accounts
            .Where(a => a.AccountId == accountId)
            .Select(a => new GetAccountResponseModel
            {
                firstName = a.AccountFirstName,
                lastName = a.AccountLastName,
                email = a.AccountEmail,
                phone = a.AccountPhone,
                role = a.Role.RoleName,
                cart = context.ShoppingCarts
                    .Where(sc => sc.AccountID == accountId)
                    .Select(sc => new CartItem
                    {
                        productId = sc.ProductID,
                        productName = sc.Product.ProductName,
                        amount = sc.ShoppingCartAmount
                    }).ToList()
            }).FirstOrDefaultAsync();

        if (response == null)
        {
            throw new NotFoundException($"Account with id {accountId} not found.");
        }
        

        return response;
    }
}