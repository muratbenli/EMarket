using EMarket.ApplicationCore.Constants;
using EMarket.ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static void SeedProductsAndCategories(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { CategoryName = "Ayakkabı" });
                context.Categories.Add(new Category { CategoryName = "Kıyafet" });
                context.SaveChanges();
            }
        }

        public static async Task SeedUsersAndRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(AuthorizationConstants.Roles.ADMINISTRATOR))
            {
                await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATOR));
            }

            var adminUserName = "muratbenli001@gmail.com";

            if (!userManager.Users.Any(x => x.UserName == adminUserName))
            {
                await userManager.CreateAsync(new ApplicationUser
                {
                    UserName = adminUserName,
                    Email = adminUserName
                }, AuthorizationConstants.DEFAULT_PASSWORD);

                var adminUser = await userManager.FindByNameAsync(adminUserName);

                await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.ADMINISTRATOR);
            }
        }
    }
}
