using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Velar.Core.Interfaces.Services;

namespace Velar.Core.Services
{
    public class FileService : IFileService
    {
        public async Task<bool> UploadFileAsync(IFormFile file, string rootPath, string uid)
        {
            bool isCopied;
            try
            {
                if (file != null)
                {
                    string fileName = DateTimeOffset.UtcNow.GetHashCode() + Path.GetExtension(file.FileName);
                    string path = Path.Combine(BuildPath(rootPath, uid), fileName);
                    await using var fileStream = new FileStream(path, FileMode.Create);
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

        public List<string> GetExplorer(string rootPath, string uid)
        {
            var directoryPath = BuildPath(rootPath, uid);
            var filePaths = Directory.GetFiles(directoryPath);
            List<string> list = new();
            foreach (var filePath in filePaths)
            {
                list.Add(Path.GetFileName(filePath));
            }
            return list;
        }

        public byte[] DownloadFile(string rootPath, string uid, string fileName)
        {
            string path = $"{BuildPath(rootPath, uid)}/{fileName}";
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return bytes;
        }

        private string BuildPath(string rootPath, string uid)
        {
            string path = Path.Combine(rootPath, $"files/{uid}");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}