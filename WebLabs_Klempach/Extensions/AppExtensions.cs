using Microsoft.AspNetCore.Builder;
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
