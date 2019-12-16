using EMarket.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMarket.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { CategoryName = "Ayakkabı" });
                context.Categories.Add(new Category { CategoryName = "Kıyafet" });
                context.SaveChanges();

            }
        }
    }
}
