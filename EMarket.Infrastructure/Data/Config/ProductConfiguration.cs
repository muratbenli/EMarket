using EMarket.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ProductName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(400);

            builder.Property(x => x.UnitPrice)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ImagePath)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // restrict silerken uyarıyor
        }
    }
}
