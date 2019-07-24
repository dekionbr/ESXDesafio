using Infrastructure.ESX.Data;
using Infrastructure.ESX.Identity;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Desafio.ESX.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var catalogContext = services.GetRequiredService<ESXContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    ESXContextSeed.SeedAsync(catalogContext).Wait();
                    AppIdentityDbContextSeed.SeedAsync(userManager).Wait();

                }
                catch (Exception ex)
                {

                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
