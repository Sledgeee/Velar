using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using Velar.Core.Entities.UserEntity;

namespace Velar.Infrastructure.Seeders
{
    public static class Users
    {
        public static void SeedUsers(this ModelBuilder builder)
        {
            var testUsers = new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid().ToString())
                .RuleFor(u => u.UserName, f => f.Internet.UserName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.PasswordHash, f => f.Internet.Password())
                .Generate(10);

            builder.Entity<User>().HasData(testUsers);
        }
    }
}