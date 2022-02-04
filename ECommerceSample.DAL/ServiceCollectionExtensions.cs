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
                // DB already contains some data
                return;
            }

            var guids = Enumerable.Range(0, 6).Select(i => Guid.NewGuid()).ToArray();

            context.ProductCategories.AddRange(
                new ProductCategory() { Id = guids[0], Name = "CATEGORY 1" },
                new ProductCategory() { Id = guids[1], Name = "CATEGORY 2" },
                new ProductCategory() { Id = guids[2], Name = "CATEGORY 3" },
                new ProductCategory() { Id = guids[3], Name = "CATEGORY 4" },
                new ProductCategory() { Id = guids[4], Name = "CATEGORY 5" },
                new ProductCategory() { Id = guids[5], Name = "CATEGORY 6" }
            );

            context.Products.AddRange(
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 1", Price = 300, ProductCategoryId = guids[0], NumberOfItemsInStock = 1 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 2", Price = 300, ProductCategoryId = guids[0], NumberOfItemsInStock = 0 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 3", Price = 300, ProductCategoryId = guids[0], NumberOfItemsInStock = 1 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 4", Price = 300, ProductCategoryId = guids[0], NumberOfItemsInStock = 3 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 5", Price = 300, ProductCategoryId = guids[1], NumberOfItemsInStock = 9 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 6", Price = 300, ProductCategoryId = guids[1], NumberOfItemsInStock = 9 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 7", Price = 300, ProductCategoryId = guids[1], NumberOfItemsInStock = 0 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 8", Price = 300, ProductCategoryId = guids[2], NumberOfItemsInStock = 0 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 9", Price = 300, ProductCategoryId = guids[2], NumberOfItemsInStock = 1 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 10", Price = 300, ProductCategoryId = guids[3], NumberOfItemsInStock = 1 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 11", Price = 300, ProductCategoryId = guids[4], NumberOfItemsInStock = 3 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 12", Price = 300, ProductCategoryId = guids[4], NumberOfItemsInStock = 3 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 13", Price = 300, ProductCategoryId = guids[4], NumberOfItemsInStock = 3 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 14", Price = 300, ProductCategoryId = guids[5], NumberOfItemsInStock = 8 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 15", Price = 300, ProductCategoryId = guids[5], NumberOfItemsInStock = 7 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 16", Price = 300, ProductCategoryId = guids[5], NumberOfItemsInStock = 7 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 17", Price = 300, ProductCategoryId = guids[5], NumberOfItemsInStock = 7 },
                new Product() { Id = Guid.NewGuid(), Name = "PRODUCT 18", Price = 300, ProductCategoryId = guids[5], NumberOfItemsInStock = 3 }
            );

            context.SaveChanges();
        }
    }
}
