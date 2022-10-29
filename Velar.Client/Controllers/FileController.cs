using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Velar.Core.Interfaces.Services;
using System.Security.Claims;

namespace Velar.Client.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly ILogger<FileController> _logger;
        private readonly IWebHostEnvironment _environment;

        public FileController(
            IFileService fileService,
            ILogger<FileController> logger,
            IWebHostEnvironment environment)
        {
            _fileService = fileService;
            _logger = logger;
            _environment = environment;
        }

        [Route("explorer")]
        public IActionResult FileExplorer()
        {
            try
            {
                var list = _fileService.GetExplorer(_environment.WebRootPath, User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View(list);
            }
            catch (Exception e)
            {
                _logger.LogError("Error {method} {url} {dateTime} {message}",
                    HttpContext.Request?.Method,
                    HttpContext.Request?.Path.Value,
                    DateTimeOffset.UtcNow,
                    e.Message);
            }
            return View("Error", 400);
        }

        [Route("upload")]
        public IActionResult ChooseFile()
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
                    DateTimeOffset.UtcNow,
                    e.Message);
            }
            return View("Error", 400);
        }

        [HttpPost]
        [Route("upload-status")]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            try
            {
                TempData["message"] = await _fileService.UploadFileAsync(file, _environment.WebRootPath, User.FindFirstValue(ClaimTypes.NameIdentifier))
                    ? "File uploaded successfully"
                    : "Something went wrong";
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError("Error {method} {url} {dateTime} {message}",
                    HttpContext.Request?.Method,
                    HttpContext.Request?.Path.Value,
                    DateTimeOffset.UtcNow,
                    e.Message);
            }
            return View("Error", 400);
        }

        [Route("download")]
        public IActionResult DownloadFile(string fileName)
        {
            try
            {
                byte[] bytes = _fileService.DownloadFile(_environment.WebRootPath, User.FindFirstValue(ClaimTypes.NameIdentifier), fileName);
                return File(bytes, "application/octet-stream", fileName);
            }
            catch (Exception e)
            {
                _logger.LogError("Error {method} {url} {dateTime} {message}",
                    HttpContext.Request?.Method,
                    HttpContext.Request?.Path.Value,
                    DateTimeOffset.UtcNow,
                    e.Message);
            }
            return View("Error", 400);
        }
    }
}
