using Core.Domain.Common;
using Core.Domain.Entities.Categories;
using Core.Domain.Entities.Products;
using Core.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Shops
{
    public class Shops : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }


        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

       
        public bool Enable { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
    }
}
