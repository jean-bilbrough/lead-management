using System;
using LeadManagementService;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LeadManagementServiceTests
{
    public static class LocalTestServer
    {
        public class ServiceOverride
        {
            private readonly Action<IServiceCollection> _overrideServices;

            public ServiceOverride(Action<IServiceCollection> overrideServices)
            {
                _overrideServices = overrideServices;
            }

            public void Override(IServiceCollection services)
            {
                _overrideServices?.Invoke(services);
            }
        }
        
        public class TestStartup : IStartup
        {
            private readonly ServiceOverride _serviceOverride;
            private readonly Startup _startup;

            public TestStartup(
                ServiceOverride serviceOverride)
            {
                _serviceOverride = serviceOverride;
                _startup = new Startup();
            }
            
            public void Configure(IApplicationBuilder app)
            {
                var hostingEnvironment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
                _startup.Configure(app, hostingEnvironment);
            }

            public IServiceProvider ConfigureServices(IServiceCollection services)
            {
                _startup.ConfigureServices(services);
                _serviceOverride.Override(services);
                return services.BuildServiceProvider();
            }
        }

        public static TestServer CreateTestServer(Action<IServiceCollection> overrideServices)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.Development.json");
            var configuration = configurationBuilder.Build();
            
            var webHostBuilder = WebHost.CreateDefaultBuilder()
                .UseEnvironment(Environments.Development)
                .UseConfiguration(configuration)
                .ConfigureServices(services => { services.AddSingleton(new ServiceOverride(overrideServices)); })
                .UseStartup<TestStartup>();
            
            var server = new TestServer(webHostBuilder);

            return server;
        }
    }
}