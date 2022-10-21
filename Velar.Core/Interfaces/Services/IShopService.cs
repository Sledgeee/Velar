using System.Threading.Tasks;
using Velar.Core.ViewModels;

namespace Velar.Core.Interfaces.Services
{
    public interface IShopService
    {
        Task<ShopViewModel> GetProductsAsync(int categoryId, int page);
    }
}