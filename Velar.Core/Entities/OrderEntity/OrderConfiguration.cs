using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Velar.Core.Entities.OrderEntity
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.DeliveryAddress).IsRequired();
            builder.Property(x => x.DeliveryMethod).IsRequired();
            builder.Property(x => x.DeliveryService).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.PaymentMethod).IsRequired();
            builder.Property(x => x.Postal).IsRequired();
            builder.Property(x => x.Region).IsRequired();
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);
            builder
                .HasOne(x => x.Cart)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.CartId);
        }
    }
}