using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Velar.Core.Interfaces.Services;

namespace Velar.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUploadFileService _uploadFileService;

        public HomeController(ILogger<HomeController> logger, IUploadFileService uploadFileService)
        {
            _logger = logger;
            _uploadFileService = uploadFileService;
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

        [Authorize]
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

        [HttpPost]
        [Route("upload-file")]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            try
            {
                bool result = await _uploadFileService.UploadFileAsync(file);
                TempData["message"] = result
                    ? "File uploaded successfully"
                    : "Something went wrong";
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
