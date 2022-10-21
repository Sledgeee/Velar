using System;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Velar.Core.Entities.CategoryEntity;

namespace Velar.Infrastructure.Seeders
{
    public static class Categories
    {
        public static void SeedCategories(this ModelBuilder builder)
        {
            int categoryId = 1;
            var testCategories = new Faker<Category>()
                .RuleFor(c => c.CategoryId, f => categoryId++)
                .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0])
                .Generate(25);
            builder.Entity<Category>().HasData(testCategories);
        }
    }
}