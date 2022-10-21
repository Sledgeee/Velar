using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Velar.Core.Entities.CartEntity;
using Velar.Core.Entities.OrderEntity;
using Velar.Core.Entities.ReviewEntity;

namespace Velar.Core.Entities.UserEntity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}