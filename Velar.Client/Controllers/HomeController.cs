using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Diagnostics;
using System.Threading.Tasks;
using Velar.Core.Interfaces.Services;

namespace Velar.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShopService _shopService;

        public HomeController(ILogger<HomeController> logger, IShopService shopService)
        {
            _logger = logger;
            _shopService = shopService;
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError("Error {method} {url} {dateTime} {message}",
                    HttpContext.Request?.Method,
                    HttpContext.Request?.Path.Value,
                    DateTime.UtcNow,
                    e.Message);
            }
            return View("Error", 400);
        }

        public async Task<IActionResult> Shop(int categoryId = -1, [FromQuery] int page = 1)
        {
            try
            {
                var model = await _shopService.GetProductsAsync(categoryId, page);
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError(Activity.Current?.Id ?? HttpContext.TraceIdentifier + $" {e.Message}");
            }
            return View("Error", 400);
        }

        [Route("search")]
        public async Task<IActionResult> SearchAsync(string term = "", int page = 1)
        {
            try
            {
                var model = await _shopService.SearchProductsAsync(term, page);
                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError(Activity.Current?.Id ?? HttpContext.TraceIdentifier + $" {e.Message}");
            }
            return View("Error", 400);
        }

        public IActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError("Error {method} {url} {dateTime} {message}",
                    HttpContext.Request?.Method,
                    HttpContext.Request?.Path.Value,
                    DateTime.UtcNow,
                    e.Message);
            }
            return View("Error", 400);
        }

        public IActionResult Contact()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError("Error {method} {url} {dateTime} {message}",
                    HttpContext.Request?.Method,
                    HttpContext.Request?.Path.Value,
                    DateTime.UtcNow,
                    e.Message);
            }
            return View("Error", 400);
        }

        public IActionResult Faq()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError("Error {method} {url} {dateTime} {message}",
                    HttpContext.Request?.Method,
                    HttpContext.Request?.Path.Value,
                    DateTime.UtcNow,
                    e.Message);
            }
            return View("Error", 400);
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error([FromQuery] int code)
        {
            try
            {
                return View(code);
            }
            catch (Exception e)
            {
                _logger.LogError("Error {method} {url} {dateTime} {message}",
                    HttpContext.Request?.Method,
                    HttpContext.Request?.Path.Value,
                    DateTime.UtcNow,
                    e.Message);
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), IsEssential = true });
            return LocalRedirect(returnUrl);
        }
    }
}
