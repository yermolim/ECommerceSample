using ECommerceSample.Core.Models.Products;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSample.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _dbContext;

        public ProductRepository(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext 
                ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IList<ProductCategory>> GetCategoriesAsync()
        {
            return await _dbContext.ProductCategories
                .Include(pc => pc.Products)
                .ToListAsync();
        }

        public async Task<ProductCategory> GetCategoryAsync(Guid id)
        {
            return await _dbContext.ProductCategories
                .Where(pc => pc.Id == id)
                .Include(pc => pc.Products)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Product>> GetCategoryProductsAsync(Guid id)
        {
            return await _dbContext.Products
                .Where(p => p.ProductCategoryId == id)
                .ToListAsync();
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await _dbContext.Products
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            return await _dbContext.Products
                .ToListAsync();
        }
    }
}
