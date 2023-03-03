using Core.Domain.Common;
using Core.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }      
        public string Brand { get; set; }
        public int CategoryId { get; set; }

        public Category category { get; set; }
    }
}
