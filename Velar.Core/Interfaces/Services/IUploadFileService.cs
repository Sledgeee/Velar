using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Velar.Core.Interfaces.Services
{
    public interface IUploadFileService
    {
        Task<bool> UploadFileAsync(IFormFile file);
    }
}