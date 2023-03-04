using AutoMapper;
using Core.Application.Dtos.ShopDtos;
using Core.Domain.Entities.Shops;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Commands.ShopCommand.CreateShop
{
    public class CreateShopCommand
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }
        public ShopDto Model { get; set; }
        public CreateShopCommand(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public string Handle()
        {
            try
            {
                string message = "Ekleme işlemi başarılı";
                var product = _mapper.Map<Shops>(Model);
                product.CreatedDate = DateTime.Now;
                product.Enable = true;
                product.UserId = id;

                _context.Shops.Add(product);
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
