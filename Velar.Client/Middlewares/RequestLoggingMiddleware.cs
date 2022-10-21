using System.Text;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using SendGrid.Helpers.Errors.Model;
using System.Net;

namespace Velar.Client.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation(
                    "Request {method} {url} {dateTime} {ip} => {statusCode}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    DateTime.UtcNow,
                    context.Connection.RemoteIpAddress,
                    context.Response?.StatusCode
                    );
            }
        }
    }
}