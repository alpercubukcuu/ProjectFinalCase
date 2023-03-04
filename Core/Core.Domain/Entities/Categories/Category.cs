using Core.Domain.Common;
using Core.Domain.Entities.Products;


namespace Core.Domain.Entities.Categories
{
    public class Category :BaseEntity
    {
        public string Name { get; set; }
        public IQueryable<Product> Products { get; set; }
       
    }
}
