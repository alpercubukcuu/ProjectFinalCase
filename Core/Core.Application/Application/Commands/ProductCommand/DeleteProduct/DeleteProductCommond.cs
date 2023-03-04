using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Commands.ProductCommand.DeleteProduct
{
    public class DeleteProductCommond
    {
        private readonly DatabaseContext _context;
        public int id { get; set;}
        public DeleteProductCommond(DatabaseContext context)
        {
            _context = context;
        }
        public string Handle()
        {
            string message = "Silme işlemi başarılı.";

            try
            {
                var deleteProduct = _context.Products.FirstOrDefault(p => p.Id == id);
                if (deleteProduct is null) return "Bu id sahip ürün bulunamadı.";

                _context.Products.Remove(deleteProduct);
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
