using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using SendGrid.Helpers.Errors.Model;
using Velar.Core.Entities.UserEntity;
using Velar.Core.Interfaces.Services;
using Velar.Core.Models.User;
using Velar.Core.Validation;
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

        public IActionResult Register(string error)
        {
            try
            {
                if (!string.IsNullOrEmpty(error))
                {
                    var list = new List<string>();
                    foreach (var parsedError in error.Split(" "))
                    {
                        list.Add(parsedError);
                    }
                    return View(list);
                }
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
        public async Task<IActionResult> ProceedRegister(RegisterViewModel model)
        {
            try
            {
                var validator = new RegisterValidator();
                var result = await validator.ValidateAsync(model);
                if (!result.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in result.Errors)
                    {
                        errorMessage = $"{error.ErrorMessage} {errorMessage}";
                    }
                    return RedirectToAction("Register", new { error = errorMessage });
                }
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    PhoneNumberConfirmed = true,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                await _authService.RegistrationAsync(user, model.Password, "User");
                await _authService.LoginAsync(model.Email, model.Password, false);
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
