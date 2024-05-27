using Microsoft.EntityFrameworkCore;

namespace APBD10.Contexts;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
}