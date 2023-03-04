using Core.Application.Dtos.ShopDtos;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Commands.ShopCommand.UpdateShop
{
    public class UpdateShopCommand
    {
        private readonly DatabaseContext _context;
        public ShopDto Model { get; set; }
        public int id { get; set; }
        public UpdateShopCommand(DatabaseContext context)
        {
            _context = context;
        }
        public string Handle()
        {
            string message = "Güncelleme işlemi başarılı";
            try
            {
                var shopList = _context.Shops.FirstOrDefault(p => p.Id == id);
                if (shopList is null) return "Bu id ait liste bulunamadı"; 

                shopList.Title = Model.Title;
                shopList.Description = Model.Description;
                shopList.Quantity = Model.Quantity;

                shopList.CategoryId = Model.CategoryId;
                shopList.ProductId = Model.ProductId;

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
