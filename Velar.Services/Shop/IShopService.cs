using System.Threading.Tasks;
using Velar.Services.Shop.ViewModels;

namespace Velar.Services.Shop
{
    public interface IShopService
    {
        Task<ShopViewModel> GetProductsAsync(int categoryId, int page);
    }
}