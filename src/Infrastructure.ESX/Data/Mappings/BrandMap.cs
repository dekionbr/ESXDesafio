using ApplicationCore.ESX.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ESX.Data.Mappings
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");

            builder.HasKey(b => b.Id)
                .HasName("Id");
            
            builder.HasIndex(b => b.Name)
                .HasName("Name")
                .IsUnique();
        }
    }
}
