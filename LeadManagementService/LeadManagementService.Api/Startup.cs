using LeadManagementService.Data;
using LeadManagementService.Interfaces.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LeadManagementService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOptions()
                .AddCors(c => c.AddPolicy("PublicPolicy", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                }))
                .AddTransient<IStorageMechanism, PostgresStorageMechanism>()
                .AddTransient<ILeadsRepository, LeadsRepository>()
                .AddControllers();

            services.AddDbContext<LeadDbContext>(options =>
            {
                options.UseNpgsql(
                    "Host=localhost;Port=5432;Username=bean_user;Password=bean_password;Database=bean_db",
                    b => b.MigrationsAssembly("LeadManagementService.Api"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseRouting()
                .UseCors("PublicPolicy")
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}