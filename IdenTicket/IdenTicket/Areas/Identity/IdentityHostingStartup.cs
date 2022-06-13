using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(IdenTicket.Areas.Identity.IdentityHostingStartup))]
namespace IdenTicket.Areas.Identity
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