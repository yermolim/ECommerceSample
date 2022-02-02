using ECommerceSample.Core.Models.Products;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository 
                ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            if (products == null || products.Count == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductAsync(Guid id)
        {
            var product = await _productRepository.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _productRepository.GetCategoriesAsync();
            if (categories == null || categories.Count == 0)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet]
        [Route("categories/{id}")]
        public async Task<IActionResult> GetCategoryAsync(Guid id)
        {
            var category = await _productRepository.GetProductAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet]
        [Route("categories/{id}/products")]
        public async Task<IActionResult> GetCategoryProductsAsync(Guid id)
        {
            var products = await _productRepository.GetCategoryProductsAsync(id);
            if (products == null || products.Count == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }
    }
}
