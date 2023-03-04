using Core.Domain.Common;
using Core.Domain.Entities.Categories;


namespace Core.Domain.Entities.Products
{
    public class Product : BaseEntity
    {       
        public string Name { get; set; }
        public double Price { get; set; }      
        public string Brand { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
   
    }
}
