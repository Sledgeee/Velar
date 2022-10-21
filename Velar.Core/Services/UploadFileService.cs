using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Velar.Core.Interfaces.Services;

namespace Velar.Core.Services
{
    public class UploadFileService : IUploadFileService
    {
        public async Task<bool> UploadFileAsync(IFormFile file)
        {
            bool isCopied;
            try
            {
                if (file.Length > 0)
                {
                    string fileName = DateTime.UtcNow.GetHashCode() + Path.GetExtension(file.FileName);
                    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files"));
                    await using var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                    await file.CopyToAsync(fileStream);
                    isCopied = true;
                }
                else
                {
                    isCopied = false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return isCopied;
        }
    }
}