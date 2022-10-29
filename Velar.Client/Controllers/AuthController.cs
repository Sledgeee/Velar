using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Errors.Model;
using Velar.Core.Entities.UserEntity;
using Velar.Core.Interfaces.Services;
using Velar.Core.Models.User;
using Velar.Core.ViewModels;

namespace Velar.Client.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(
            ILogger<AuthController> logger,
            IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        public IActionResult Login()
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
        public async Task<IActionResult> ProceedLogin(string email, string password, string returnUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
                {
                    return View("Login", "Empty value is not acceptable");
                }
                await _authService.LoginAsync(email, password, Request.Form["remember"] == "on");
                return LocalRedirect(returnUrl ?? "/");
            }
            catch (UnauthorizedException e)
            {
                return View("Login", e.Message);
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

        public IActionResult Register()
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
        public async Task<IActionResult> ProceedRegister(string firstName, string lastName, string email, string phoneNumber, string password, string repeatPassword)
        {
            try
            {
                if (!password.Equals(repeatPassword))
                {
                    return View("Register", "Passwords do not match");
                }
                var user = new User
                {
                    UserName = email,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    PhoneNumberConfirmed = true,
                    FirstName = firstName,
                    LastName = lastName
                };
                await _authService.RegistrationAsync(user, password, "User");
                await _authService.LoginAsync(email, password, false);
                return RedirectToAction("Index", "Home", new { area = "" });
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

        [Authorize]
        public async Task<IActionResult> Logout([FromQuery] bool isAuthenticated = false)
        {
            try
            {
                if (isAuthenticated)
                {
                    await _authService.LogoutAsync();
                }
                return RedirectToAction("Index", "Home", new { area = "" });
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

        [Route("[controller]/forgot-password")]
        public IActionResult ForgotPassword()
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

        public async Task<IActionResult> SendResetMailAsync(string email)
        {
            try
            {
                await _authService.SentResetPasswordTokenAsync(email);
                return View("MailSuccess", new MailSuccessViewModel
                {
                    Title = "Reset link sent successfully",
                    Text = "Check your E-mail and use reset link"
                });
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

        [Route("[controller]/reset-password")]

        public IActionResult ResetPassword([FromQuery] string uid, [FromQuery] string token)
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
        public async Task<IActionResult> ProceedResetPassword([FromQuery] string uid, [FromQuery] string token, string password, string repeatPassword)
        {
            try
            {
                if (!password.Equals(repeatPassword))
                {
                    return RedirectToAction("ResetPassword", "Auth", new { area = "", uid, token });
                }
                var changePassword = new ChangePassword
                {
                    UserId = uid,
                    NewPassword = password,
                    Code = token
                };
                await _authService.ResetPasswordAsync(changePassword);
                return RedirectToAction("Login", "Auth", new { area = "" });
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

        [Route("[controller]/mail-success")]
        public IActionResult MailSuccess()
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
    }
}
