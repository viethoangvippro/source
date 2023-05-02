using Microsoft.EntityFrameworkCore;

using TruongVietHoang_QLThongTin_MVC.Models;

namespace TruongVietHoang_QLThongTin_MVC.Data
{
    public class CdbContext : DbContext
    {
        public CdbContext(DbContextOptions<CdbContext> options) : base(options) { }

        public DbSet<Models.User> users { get; set; }
        public DbSet<Models.Tinh> tinhs { get; set; }   
        public DbSet<Models.Huyen> huyens { get; set; }
    }
}
