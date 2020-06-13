using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabs_Klempach.MiddleWare;

namespace WebLabs_Klempach.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogMiddleware>();
        }
    }
}
