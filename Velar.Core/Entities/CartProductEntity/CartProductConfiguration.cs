using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Velar.Core.Entities.CartProductEntity
{
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(x => new { x.CartId, x.ProductId });
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.ItemPrice).IsRequired();
            builder
                .HasOne(x => x.Cart)
                .WithMany(x => x.CartProducts)
                .HasForeignKey(x => x.CartId);
            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.CartProducts)
                .HasForeignKey(x => x.ProductId);
        }
    }
}