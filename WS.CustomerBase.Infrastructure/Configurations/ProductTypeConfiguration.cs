using Microsoft.EntityFrameworkCore;
using WS.CustomerBase.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WS.CustomerBase.Infrastructure.Configurations;

public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(250).IsRequired();
        builder.Property(x => x.Price).HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnUpdate();
    }
}