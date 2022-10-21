using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Velar.Core.Entities.CartEntity;
using Velar.Core.Entities.CartProductEntity;
using Velar.Core.Entities.CategoryEntity;
using Velar.Core.Entities.OrderEntity;
using Velar.Core.Entities.ProductEntity;
using Velar.Core.Entities.ReviewEntity;
using Velar.Core.Entities.UserEntity;
using Velar.Core.Entities.VendorCategoryEntity;
using Velar.Core.Entities.VendorEntity;
using Velar.Infrastructure.Seeders;

namespace Velar.Infrastructure.Context
{
    public class VelarDbContext : IdentityDbContext<User>
    {
        public VelarDbContext(DbContextOptions<VelarDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VendorCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new VendorConfiguration());
            modelBuilder.SeedUsers();
            modelBuilder.SeedCategories();
            modelBuilder.SeedVendors();
            modelBuilder.SeedProducts();
            modelBuilder.SeedReviews();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartProduct> CartProducts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorCategory> VendorCategories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    }
}