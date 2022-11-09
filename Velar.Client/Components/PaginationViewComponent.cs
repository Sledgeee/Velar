using Microsoft.AspNetCore.Mvc;
using Velar.Core.ViewModels;

namespace Velar.Client.Components
{
    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ShopPaginationViewModel model)
        {
            return View(model);
        }
    }
}