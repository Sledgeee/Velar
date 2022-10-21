using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Velar.Core.Entities.VendorCategoryEntity
{
    public class VendorCategoryConfiguration : IEntityTypeConfiguration<VendorCategory>
    {
        public void Configure(EntityTypeBuilder<VendorCategory> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.VendorId });
            builder
                .HasOne(x => x.Vendor)
                .WithMany(x => x.VendorCategories)
                .HasForeignKey(x => x.VendorId);
            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.VendorCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}