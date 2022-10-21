using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Velar.Core.Models.User;

namespace Velar.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<PersonalInfo> GetUserPersonalInfoAsync(string userId);
        Task ChangeInfoAsync(string userId, ChangeInfo userChangeInfo);
    }
}
