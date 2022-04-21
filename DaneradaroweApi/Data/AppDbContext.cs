using Microsoft.EntityFrameworkCore;

namespace DaneradaroweApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }

        public DbSet<DataType> DataTypes { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Radar> Radars { get; set; } = null!;
        public DbSet<Scan> Scans { get; set; } = null!;
        public DbSet<Volume> Volumes { get; set; } = null!;
        public DbSet<CompositeImage> CompositeImages { get; set; } = null!;
    }
}