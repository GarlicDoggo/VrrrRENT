using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(VrrrRent.Areas.Identity.IdentityHostingStartup))]
namespace VrrrRent.Areas.Identity
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