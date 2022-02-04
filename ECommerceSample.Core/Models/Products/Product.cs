using System;

namespace ECommerceSample.Core.Models.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int NumberOfItemsInStock { get; set; }

        public Guid ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
