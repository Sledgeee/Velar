using System;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Velar.Core.Entities.ReviewEntity;
using Velar.Core.Entities.VendorEntity;

namespace Velar.Infrastructure.Seeders
{
    public static class Reviews
    {
        public static void SeedReviews(this ModelBuilder builder)
        {
            Randomizer.Seed = new Random(DateTime.Now.GetHashCode());
            int reviewId = 1;
            var testReviews = new Faker<Review>()
                .RuleFor(r => r.ReviewId, f => reviewId++)
                .RuleFor(r => r.Email, f => f.Internet.Email())
                .RuleFor(r => r.Subject, f => f.Commerce.ProductName())
                .RuleFor(r => r.Body, f => f.Commerce.ProductDescription())
                .RuleFor(r => r.Name, f => f.Name.FullName())
                .RuleFor(r => r.Stars, f => f.Random.Number(4) + 1)
                .RuleFor(r => r.ProductId, f => f.Random.Number(99) + 1)
                .Generate(50);
            builder.Entity<Review>().HasData(testReviews);
        }
    }
}