using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Dtos.ShopDtos
{
    public class ShopDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }


        //public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
