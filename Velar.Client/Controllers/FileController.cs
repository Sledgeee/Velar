using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Velar.Core.Interfaces.Services;

namespace Velar.Client.Controllers
{
    public class FileController : Controller
    {
        private readonly IUploadFileService _uploadFileService;
        private readonly ILogger<FileController> _logger;

        public FileController(IUploadFileService uploadFileService, ILogger<FileController> logger)
        {
            _uploadFileService = uploadFileService;
            _logger = logger;
        }

        [Route("file-explorer")]
        public IActionResult FileExplorer()
        {
            var filePaths = Directory.GetFiles(Path.Combine(HttpContext.Request.PathBase, "wwwroot/Files/"));
            return View(filePaths);
        }

        [Route("choose-file")]
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

        //public IActionResult DownloadFile(string fileName)
        //{
        //    string path = Path.Combine(HttpContext.Request.Path.Value, "Files/") + fileName;
        //}
    }
}
