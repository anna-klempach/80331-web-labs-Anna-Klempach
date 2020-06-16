using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WebLabs_Klempach.Areas.Identity.IdentityHostingStartup))]
namespace WebLabs_Klempach.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}