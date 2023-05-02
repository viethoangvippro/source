using ConnectDb.Models;
using Microsoft.EntityFrameworkCore;
namespace ConnectDb.Data
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
        { 

        }
        public DbSet<Category> categories { get; set; }

        public DbSet<Product> products { get; set; }
    }
}
