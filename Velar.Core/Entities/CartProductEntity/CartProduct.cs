using Velar.Core.Entities.CartEntity;
using Velar.Core.Entities.ProductEntity;

namespace Velar.Core.Entities.CartProductEntity
{
    public class CartProduct
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ItemPrice { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}