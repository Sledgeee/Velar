using System.Collections.Generic;
using Velar.Infrastructure.Models.ProductModel;

namespace Velar.Services.Shop.ViewModels
{
    public class ShopViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
    }
}