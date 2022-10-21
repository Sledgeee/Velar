using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Velar.Core.Entities.UserEntity;
using Velar.Core.Interfaces.Services;

namespace Velar.Client.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UserController(ILogger<UserController> logger, IUserService userService, UserManager<User> userManager)
        {
            _logger = logger;
            _userService = userService;
            _userManager = userManager;
        }

        [Route("profile")]
        public async Task<IActionResult> Profile()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userService.GetUserPersonalInfoAsync(userId);
                return View(user);
            }
            catch (Exception e)
            {
                _logger.LogError((Activity.Current?.Id ?? HttpContext.TraceIdentifier) + $" {e.Message}");
            }
            return View("Error", 400);
        }
    }
}
