using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSample.Core.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int NumberOfItemsInStock { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
