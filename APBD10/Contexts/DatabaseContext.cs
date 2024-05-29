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
    }
}