using System.Collections.Generic;
using Velar.Core.Entities.CartProductEntity;
using Velar.Core.Entities.CategoryEntity;
using Velar.Core.Entities.ReviewEntity;
using Velar.Core.Entities.VendorEntity;

namespace Velar.Core.Entities.ProductEntity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string MediumImage { get; set; }
        public int CategoryId { get; set; }
        public int VendorId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
