using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Velar.Core.Entities.ProductEntity
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(16,2)").IsRequired();
            builder.Property(x => x.MediumImage).IsRequired();
            builder
                .HasOne(x => x.Vendor)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.VendorId);
            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}