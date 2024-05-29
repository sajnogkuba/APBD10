using APBD10.Contexts;
using APBD10.DTOs;
using APBD10.Models;

namespace APBD10.Services;

public interface IProductService
{
    Task AddProductAsync(AddProductDTO addProductDto);
}

public class ProductService(DatabaseContext databaseContext) : IProductService
{
    public async Task AddProductAsync(AddProductDTO addProductDto)
    {
        var product = new Product
        {
            ProductName = addProductDto.productName,
            ProductWidth = addProductDto.productWeight,
            ProductHeight = addProductDto.productHeight,
            ProductDepth = addProductDto.productDepth,
            ProductCategories = addProductDto.productCategories.Select(categoryId => new ProductCategory()
            {
                CategoryId = categoryId
            }).ToList()
        };
        databaseContext.Products.Add(product);
        await databaseContext.SaveChangesAsync();
    }
}