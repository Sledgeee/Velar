using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Velar.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
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

        [Route("about")]
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

        [Route("contact")]
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

        [Route("faq")]
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

        [Route("error/{code}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int code)
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
    }
}
