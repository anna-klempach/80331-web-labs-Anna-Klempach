using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabs_Klempach.Services;

namespace WebLabs_Klempach.MiddleWare
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ILoggerFactory factory)
        {
            var time = DateTime.Now;
            await _next(context);
            var statusCode = context.Response.StatusCode;
            if (statusCode != StatusCodes.Status200OK)
            {
                var logger = factory.CreateLogger<FileLogger>();
                logger.LogInformation($"{time.ToShortDateString()} - {time.ToLongTimeString()}: "
                    + $"url: {context.Request.Path}{context.Request.QueryString} returns {statusCode}");
            }
        }
    }
}
