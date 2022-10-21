using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Velar.Core.Entities.CategoryEntity;
using Velar.Core.Entities.ProductEntity;
using Velar.Core.Entities.VendorEntity;
using Velar.Core.Interfaces.Repositories;
using Velar.Core.ViewModels;
using Velar.Core.Interfaces.Services;

namespace Velar.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Vendor> _vendorRepository;

        public ShopService(
            IRepository<Product> productRepository,
            IRepository<Category> categoryRepository,
            IRepository<Vendor> vendorRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _vendorRepository = vendorRepository;
        }

        public async Task<ShopViewModel> GetProductsAsync(int categoryId, int page)
        {
            int pageSize = 21;
            var products =
                (await _productRepository.GetAllAsync())
                .OrderByDescending(x => x.ProductId);
            var pagesCount = Convert.ToInt32(Math.Ceiling(products.Count() / (decimal)pageSize));
            var vendors = await GetVendorsAsync();
            var categories = await GetCategoriesAsync();

            return new ShopViewModel()
            {
                Vendors = vendors,
                Categories = categories,
                Products = products.Skip((page - 1) * pageSize).Take(pageSize),
                PageCount = pagesCount,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        private async Task<IEnumerable<Vendor>> GetVendorsAsync()
        {
            var vendors =
                (await _vendorRepository.GetAllAsync())
                .OrderByDescending(x => x.VendorId);
            return vendors;
        }

        private async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories =
                (await _categoryRepository.GetAllAsync())
                .OrderByDescending(x => x.CategoryId);
            return categories;
        }
    }
}
