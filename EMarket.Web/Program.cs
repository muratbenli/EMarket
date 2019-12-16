using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EMarket.ApplicationCore.Entities;
using EMarket.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EMarket.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                ApplicationDbContextSeed.Seed(dbContext);

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await ApplicationDbContextSeed.SeedUsersAsync(userManager, roleManager);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
