using Core.Application.Dtos.ProductDtos;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Commands.ProductCommand.UpdateProduct
{
    public class UpdateProductCommond
    {
        private readonly DatabaseContext _context;
        public ProductDto Model { get; set; }
        public int id { get; set; }
        public UpdateProductCommond(DatabaseContext context)
        {
            _context = context;
        }
        public string Handle()
        {
            string message = "Güncelleme işlemi başarılı";
            try
            {
                var updateProduct = _context.Products.FirstOrDefault(p => p.Id == id);
                if (updateProduct is null) return "Bu id sahip ürün bulunamadı.";

                updateProduct.Name = Model.Name;
                updateProduct.Price = Model.Price;
                updateProduct.Brand = Model.Brand;
                updateProduct.CategoryId = Model.CategoryId;
                updateProduct.CreatedDate = DateTime.Now;

                _context.SaveChanges();

                return message;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
          
        }
    }
}
