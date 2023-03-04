using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Dtos.ProductDtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
