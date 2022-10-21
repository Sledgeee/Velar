using System.Collections.Generic;
using Velar.Core.Entities.ProductEntity;
using Velar.Core.Entities.VendorCategoryEntity;

namespace Velar.Core.Entities.VendorEntity
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<VendorCategory> VendorCategories { get; set; }
    }
}