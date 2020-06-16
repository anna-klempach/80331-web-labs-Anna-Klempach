using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebLabs_Klempach.Services;

namespace WebLabs_Klempach
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(log =>
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "fileInfoLog.txt");
                    log.ClearProviders();
                    log.AddProvider(new FileLoggerProvider(path));
                    log.AddFilter("Microsoft", LogLevel.None);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
