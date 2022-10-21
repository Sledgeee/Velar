using Bogus;
using Microsoft.EntityFrameworkCore;
using Velar.Core.Entities.VendorEntity;

namespace Velar.Infrastructure.Seeders
{
    public static class Vendors
    {
        public static void SeedVendors(this ModelBuilder builder) 
        {
            int vendorId = 1;
            var testVendors = new Faker<Vendor>()
                .RuleFor(v => v.VendorId, f => vendorId++)
                .RuleFor(v => v.Name, f => f.Company.CompanyName())
                .Generate(10);
            builder.Entity<Vendor>().HasData(testVendors);
        }
    }
}