using System.Collections.Generic;
using Velar.Core.Entities.CartProductEntity;
using Velar.Core.Entities.OrderEntity;
using Velar.Core.Entities.UserEntity;

namespace Velar.Core.Entities.CartEntity
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ProductsCount { get; set; }
        public decimal MoneyAmount { get; set; }
        public string? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}