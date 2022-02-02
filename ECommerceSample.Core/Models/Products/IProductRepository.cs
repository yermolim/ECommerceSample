using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSample.Core.Models.Products
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(Guid id);

        Task<IList<ProductCategory>> GetCategoriesAsync();

        Task<ProductCategory> GetCategoryAsync(Guid id);

        Task<IList<Product>> GetCategoryProductsAsync(Guid id);
    }
}
