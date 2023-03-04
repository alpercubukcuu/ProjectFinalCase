using Core.Domain.Common;
using Core.Domain.Entities.Products;


namespace Core.Domain.Entities.Categories
{
    public class Category :BaseEntity
    {
       
        public Category()
        {
            Products = new List<Product>();
        }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

    }
}
