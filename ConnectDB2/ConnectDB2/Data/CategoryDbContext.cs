using ConnectDB2.Models;
using Microsoft.EntityFrameworkCore;
namespace ConnectDB2.Data
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
        {

        }
        public DbSet<Models.Category> categories { get; set; }

        public DbSet<Models.Product> products { get; set; }
    }
}
