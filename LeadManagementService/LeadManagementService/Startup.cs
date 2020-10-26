using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using LeadManagementService.NewLeads;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
                .AddTransient<LeadsRepository>()
                .AddControllers();

            services.AddDbContext<LeadDbContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Username=bean_user;Password=bean_password;Database=bean_db");
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