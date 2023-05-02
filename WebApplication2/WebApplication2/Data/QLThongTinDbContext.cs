using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class QLThongTinDbContext : DbContext
    {
        public QLThongTinDbContext(DbContextOptions<QLThongTinDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Pro> Pros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Cat>().ToTable("Cat");
            modelBuilder.Entity<Pro>().ToTable("Pro");
            modelBuilder.Entity<Pro>().HasOne(p => p.Cat)
                .WithMany(c => c.Pros)
                .HasForeignKey(p => p.IdCat);

        }
    }
}
