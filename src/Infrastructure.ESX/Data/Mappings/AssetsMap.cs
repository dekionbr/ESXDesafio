using ApplicationCore.ESX.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ESX.Data.Mappings
{
    public class AssetsMap : IEntityTypeConfiguration<Assets>
    {
        public void Configure(EntityTypeBuilder<Assets> builder)
        {
            builder.ToTable("Assets");

            builder.HasKey(b => b.Id)
                .HasName("Id");

            builder.Property(b => b.Name)
                .HasColumnName("Name");

            builder.Property(b => b.Description)
                .HasColumnName("Description");

            builder.Property(b => b.NumberAssets)
                .HasColumnName("NumberAssets")
                .HasDefaultValueSql("NEXT VALUE FOR autoincremento");

        }
    }
}
