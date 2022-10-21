using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Velar.Core.Entities.UserEntity;
using System.Collections.Generic;
using System.Threading.Tasks;
using SendGrid.Helpers.Errors.Model;
using Velar.Core.Interfaces.Repositories;
using Velar.Core.Interfaces.Services;
using Velar.Core.Models.Mail;
using Velar.Core.Models.User;

namespace Velar.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepository<User> _userRepository;

        public UserService(UserManager<User> userManager,
            IRepository<User> userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<PersonalInfo> GetUserPersonalInfoAsync(string userId)
        {
            var user = await _userRepository.GetByKeyAsync(userId);
            var userPersonalInfo = new PersonalInfo
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
            };
            return userPersonalInfo;
        }

        public async Task ChangeInfoAsync(string userId, ChangeInfo changeInfo)
        {
            var userObject = await _userManager.FindByNameAsync(changeInfo.UserName);

            if (userObject != null && userObject.Id != userId)
            {
                throw new BadRequestException("Username already exists");
            }

            var user = await _userRepository.GetByKeyAsync(userId);

            if (user == null)
            {
                throw new NullReferenceException("Something went wrong");
            }

            user.FirstName = changeInfo.FirstName;
            user.LastName = changeInfo.LastName;
            user.UserName = changeInfo.UserName;

            await _userRepository.UpdateAsync(user);

            await _userManager.UpdateNormalizedUserNameAsync(user);

            await _userRepository.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
