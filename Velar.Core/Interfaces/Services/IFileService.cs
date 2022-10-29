using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Velar.Core.Interfaces.Services
{
    public interface IFileService
    {
        Task<bool> UploadFileAsync(IFormFile file, string rootPath, string uid);
        List<string> GetExplorer(string rootPath, string uid);
        byte[] DownloadFile(string rootPath, string uid, string fileName);
    }
}