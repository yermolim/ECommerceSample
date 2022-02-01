using ECommerceSample.Core.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id}")]
        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("categories")]
        public IEnumerable<ProductCategory> GetCategories()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("categories/{id}")]
        public ProductCategory GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("categories/{id}/products")]
        public Product GetCategoryProducts(int id)
        {
            throw new NotImplementedException();
        }
    }
}
