using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Commands.ShopCommand.DeleteShop
{
    public class DeleteShopCommand
    {
        private readonly DatabaseContext _context;
        public int id { get; set;}
        public DeleteShopCommand(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        public string Handle()
        {
            try
            {
                string message = "Silme işlemi başarılı";
                var shopList = _context.Shops.FirstOrDefault(p => p.Id == id);
                _context.Shops.Remove(shopList);
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
