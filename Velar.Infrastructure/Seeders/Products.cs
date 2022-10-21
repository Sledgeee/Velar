using System;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Velar.Core.Entities.ProductEntity;

namespace Velar.Infrastructure.Seeders
{
    public static class Products
    {
        public static void SeedProducts(this ModelBuilder builder)
        {
            int productId = 1;
            var testProducts = new Faker<Product>()
                .RuleFor(p => p.ProductId, f => productId++)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => Convert.ToDecimal(f.Commerce.Price(5, 5000)))
                .RuleFor(p => p.MediumImage,
                    f => "https://localhost:5001/images/products/product-" + (f.Random.Number(4) + 1) + ".jpg"
                    )
                .RuleFor(p => p.CategoryId, f => f.Random.Number(24) + 1)
                .RuleFor(p => p.VendorId, f => f.Random.Number(9) + 1)
                .Generate(100);
            builder.Entity<Product>().HasData(testProducts);
        }
    }
}