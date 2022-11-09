using System.Collections.Generic;
using Velar.Core.Entities.CategoryEntity;
using Velar.Core.Entities.ProductEntity;
using Velar.Core.Entities.VendorEntity;

namespace Velar.Core.ViewModels
{
    public class ShopViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Vendor> Vendors { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public ShopPaginationViewModel ShopPagination { get; set; }
    }
}