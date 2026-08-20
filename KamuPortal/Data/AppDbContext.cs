using Microsoft.EntityFrameworkCore;
using KamuPortal.Models;

namespace KamuPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Haber> Haberler { get; set; } = null!;
        public DbSet<Admin> Adminler { get; set; }
        public DbSet<Duyurular> Duyurular { get; set; }
    }
}