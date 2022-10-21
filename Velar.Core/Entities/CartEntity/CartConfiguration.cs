using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Velar.Core.Entities.CartEntity
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.CartId);
            builder.Property(x => x.MoneyAmount).HasColumnType("decimal(16,2)").HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.ProductsCount).HasDefaultValue(0).IsRequired();
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Carts)
                .HasForeignKey(x => x.UserId);
        }
    }
}