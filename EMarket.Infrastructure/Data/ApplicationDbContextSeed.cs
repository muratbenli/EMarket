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
                context.Categories.AddRange(Categories());
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

        // this method calls dump categories and products
        private static readonly Random rnd = new Random();
        public static List<Category> Categories(int count = 5, int productCountPerCategory = 99)
        {
            var categories = new List<Category>();
            var pid = 1;

            for (int i = 1; i <= count; i++)
            {
                var category = new Category
                {
                    CategoryName = "Category " + i,
                    Products = new List<Product>()
                };

                for (int j = 0; j < productCountPerCategory; j++)
                {
                    category.Products.Add(
                        new Product
                        {
                            CategoryId = i,
                            ProductName = "Product " + pid,
                            UnitPrice = rnd.Next(1, 11) * 10.00m
                        }
                    );
                    pid++;
                }

                categories.Add(category);
            }

            return categories;
        }
    }
}
