using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using Microsoft.Extensions.Logging;
using Velar.Core.Interfaces.Services;

namespace Velar.Client.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IShopService _shopService;

        public ShopController(ILogger<ShopController> logger, IShopService shopService)
        {
            _logger = logger;
            _shopService = shopService;
        }

        [Route("[controller]/product-details")]
        public IActionResult ProductDetails(int id)
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError(Activity.Current?.Id ?? HttpContext.TraceIdentifier + $" {e.Message}");
            }
            return View("Error", 400);
        }

        public IActionResult Cart()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError(Activity.Current?.Id ?? HttpContext.TraceIdentifier + $" {e.Message}");
            }
            return View("Error", 400);
        }

        public IActionResult Checkout()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError(Activity.Current?.Id ?? HttpContext.TraceIdentifier + $" {e.Message}");
            }
            return View("Error", 400);
        }
    }
}
