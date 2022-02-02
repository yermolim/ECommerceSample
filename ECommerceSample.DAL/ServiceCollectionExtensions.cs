using ECommerceSample.Core.Models.Products;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;

namespace ECommerceSample.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddECommerceContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            var context = services.BuildServiceProvider()
                .GetService<ECommerceDbContext>();
            // TODO: Be careful with this. Can lead to data loss. Only for testing
            context.Database.Migrate();
            SeedData(context);

            return services;
        }

        /// <summary>
        /// Seed data for debug purposes
        /// </summary>
        /// <param name="context">DB context</param>
        private static void SeedData(ECommerceDbContext context)
        {
            if (context.ProductCategories.Any())
            {
                // DB already contain some data
                return;
            }

            var guids = Enumerable.Range(0, 6).Select(i => Guid.NewGuid()).ToArray();

            context.ProductCategories.AddRange(
                new ProductCategory() { Id = guids[0], Name = "Category 1" },
                new ProductCategory() { Id = guids[1], Name = "Category 2" },
                new ProductCategory() { Id = guids[2], Name = "Category 3" },
                new ProductCategory() { Id = guids[3], Name = "Category 4" },
                new ProductCategory() { Id = guids[4], Name = "Category 5" },
                new ProductCategory() { Id = guids[5], Name = "Category 6" }
            );

            context.Products.AddRange(
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[0], NumberOfItemsInStock = 1 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[0], NumberOfItemsInStock = 0 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[0], NumberOfItemsInStock = 1 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[0], NumberOfItemsInStock = 3 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[1], NumberOfItemsInStock = 9 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[1], NumberOfItemsInStock = 9 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[1], NumberOfItemsInStock = 0 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[2], NumberOfItemsInStock = 0 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[2], NumberOfItemsInStock = 1 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[3], NumberOfItemsInStock = 1 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[4], NumberOfItemsInStock = 3 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[4], NumberOfItemsInStock = 3 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[4], NumberOfItemsInStock = 3 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[5], NumberOfItemsInStock = 8 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT NAME", Price = 300, ProductCategoryId = guids[5], NumberOfItemsInStock = 7 }
            );

            context.SaveChanges();
        }
    }
}
