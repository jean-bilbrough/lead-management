using LeadManagementService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LeadManagementService
{
    public static class WebHostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<LeadDbContext>();
 
                context.Database.Migrate();
 
                new LeadDocumentSeeder(context).SeedData();
            }
 
            return host;
        }
    }
}