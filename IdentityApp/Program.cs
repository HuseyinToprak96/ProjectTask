using CoreLayer.Entities.UserEntity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var identityDbContext = scope.ServiceProvider.GetRequiredService<RepositoryLayer.IdentityDBContext.IdentityDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserApp>>();
            identityDbContext.Database.Migrate();
            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(new UserApp() { UserName = "SysAdmin", Email = "sysadmin1@outlook.com" }, "Password12*").Wait();
                userManager.CreateAsync(new UserApp() { UserName = "Admin", Email = "admin1@outlook.com" }, "Password12*").Wait();
                userManager.CreateAsync(new UserApp() { UserName = "User1", Email = "user1@outlook.com" }, "Password12*").Wait();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
