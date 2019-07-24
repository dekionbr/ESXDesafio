using ApplicationCore.ESX.Entities;
using Infrastructure.ESX.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ESX.Data
{
    public class ESXContext : DbContext
    {
        public ESXContext(DbContextOptions<ESXContext> options) : base(options)
        { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Assets> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BrandMap());
            modelBuilder.ApplyConfiguration(new AssetsMap());
        }
    }
}
