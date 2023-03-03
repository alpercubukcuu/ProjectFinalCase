using Core.Domain.Common;
using Core.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Categories
{
    public class Category :BaseEntity
    {
        public string Name { get; set; }
        public IQueryable<Product> Products { get; set; }
    }
}
