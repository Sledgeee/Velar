using System.Collections.Generic;
using Velar.Core.Entities.ProductEntity;
using Velar.Core.Entities.VendorCategoryEntity;

namespace Velar.Core.Entities.CategoryEntity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int Realcat { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<VendorCategory> VendorCategories { get; set; }
    }
}