using APBD10.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductsCategories { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ShoppingCart>()
            .HasKey(cart =>  new { cart.AccountID, cart.ProductID });
        
        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });

        modelBuilder.Entity<Role>().HasData(new List<Role>()
        {
            new()
            {
                RoleId = 1,
                RoleName = "Admin"
            },
            new()
            {
                RoleId = 2,
                RoleName = "User"
            },
            new()
            {
                RoleId = 3,
                RoleName = "Guest"
            }
        });
        
        modelBuilder.Entity<Account>().HasData(new List<Account>()
        {
            new()
            {
                AccountId = 1,
                RoleId = 1,
                AccountFirstName = "John",
                AccountLastName = "Doe",
                AccountEmail = "john.doe@gmail.com",
                AccountPhone = "123456789"
            },
            new()
            {
                AccountId = 2,
                RoleId = 2,
                AccountFirstName = "Alice",
                AccountLastName = "Smith",
                AccountEmail = "alice.smith@gmail.com",
                AccountPhone = "987654321"
            },
            new()
            {
                AccountId = 3,
                RoleId = 3,
                AccountFirstName = "Bob",
                AccountLastName = "Brown",
                AccountEmail = "bob.brown@gmail.com",
                AccountPhone = "456789123"
            }
        });
        
        modelBuilder.Entity<Product>().HasData(new List<Product>()
        {
            new()
            {
                ProductId = 1,
                ProductName = "Product 1",
                ProductWidth = 1.1m,
                ProductHeight = 2.2m,
                ProductDepth = 3.3m
            },
            new()
            {
                ProductId = 2,
                ProductName = "Product 2",
                ProductWidth = 2m,
                ProductHeight = 3.4m,
                ProductDepth = 1.4m
            },
            new()
            {
                ProductId = 3,
                ProductName = "Product 3",
                ProductWidth = 1.1m,
                ProductHeight = 2.2m,
                ProductDepth = 3.3m
            }
        });
        
        modelBuilder.Entity<ShoppingCart>().HasData(new List<ShoppingCart>()
        {
            new()
            {
                AccountID = 1,
                ProductID = 1,
                ShoppingCartAmount = 13
            },
            new()
            {
                AccountID = 2,
                ProductID = 3,
                ShoppingCartAmount = 2
            },
            new()
            {
                AccountID = 3,
                ProductID = 2,
                ShoppingCartAmount = 5
            }
        });
        
        modelBuilder.Entity<Category>().HasData(new List<Category>()
        {
            new()
            {
                CategoryId = 1,
                CategoryName = "Category 1"
            },
            new()
            {
                CategoryId = 2,
                CategoryName = "Category 2"
            },
            new()
            {
                CategoryId = 3,
                CategoryName = "Category 3"
            }
        });
        
        modelBuilder.Entity<ProductCategory>().HasData(new List<ProductCategory>()
        {
            new()
            {
                ProductId = 1,
                CategoryId = 1
            },
            new()
            {
                ProductId = 2,
                CategoryId = 2
            },
            new()
            {
                ProductId = 3,
                CategoryId = 3
            }
        });
    }
}