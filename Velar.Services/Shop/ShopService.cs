using System;
using System.Linq;
using System.Threading.Tasks;
using Velar.Infrastructure.Models.ProductModel;
using Velar.Infrastructure.Repositories;
using Velar.Services.Shop.ViewModels;

namespace Velar.Services.Shop
{
    public class ShopService : IShopService
    {
        private readonly IRepository<Product> _productRepository;

        public ShopService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ShopViewModel> GetProductsAsync(int categoryId, int page)
        {
            var products =
                (await _productRepository.GetAllAsync())
                .OrderByDescending(x => x.ProductId);
            var pagesCount = Convert.ToInt32(Math.Ceiling(products.Count() / 21m));

            return new ShopViewModel()
            {
                Products = products.Skip((page - 1) * 21).Take(21),
                PageCount = pagesCount,
                PageNumber = page
            };
        }
    }
}