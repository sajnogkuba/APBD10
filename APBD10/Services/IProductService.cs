using APBD10.Contexts;
using APBD10.DTOs;
using APBD10.Exceptions;
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
        if (addProductDto.productName == null)
        {
            throw new AddProductException("Product name is required.");
        }
        
        if (addProductDto.productName.Length > 100)
        {
            throw new AddProductException($"Product name is too long. It should be at most 100 characters long." +
                                          $"Your product name is {addProductDto.productName.Length} characters long.");
        }

        if (addProductDto.productWeight <= 0)
        {
            throw new AddProductException("Product weight should be greater than 0. Your product weight is " +
                                          $"{addProductDto.productWeight}.");
        }
        
        if (addProductDto.productWeight > 999.99m)
        {
            throw new AddProductException("Product weight should be less than 1000. Your product weight is " +
                                          $"{addProductDto.productWeight}.");
        }
        
        if(addProductDto.productHeight <= 0)
        {
            throw new AddProductException("Product height should be greater than 0. Your product height is " +
                                          $"{addProductDto.productHeight}.");
        }
        
        if(addProductDto.productHeight > 999.99m)
        {
            throw new AddProductException("Product height should be less than 1000. Your product height is " +
                                          $"{addProductDto.productHeight}.");
        }
        
        if(addProductDto.productDepth <= 0)
        {
            throw new AddProductException("Product depth should be greater than 0. Your product depth is " +
                                          $"{addProductDto.productDepth}.");
        }
        
        if(addProductDto.productDepth > 999.99m)
        {
            throw new AddProductException("Product depth should be less than 1000. Your product depth is " +
                                          $"{addProductDto.productDepth}.");
        }
        
        if(addProductDto.productCategories == null || addProductDto.productCategories.Count == 0)
        {
            throw new AddProductException("Product should have at least one category.");
        }
        
        foreach (var productCategory in addProductDto.productCategories)
        {
            var category = await databaseContext.Categories.FindAsync(productCategory);
            if (category == null)
            {
                throw new AddProductException($"Category with id {productCategory} does not exist.");
            }
        }
        

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