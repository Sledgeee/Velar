using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Velar.Core.Entities.CategoryEntity
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ParentId).HasDefaultValue(1).IsRequired();
            builder.Property(x => x.Realcat).HasDefaultValue(0).IsRequired();
        }
    }
}