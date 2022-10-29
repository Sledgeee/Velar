using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace Velar.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            return LocalRedirect(returnUrl);
        }
    }
}
