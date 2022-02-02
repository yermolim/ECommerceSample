using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSample.Core.Models.Products
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
