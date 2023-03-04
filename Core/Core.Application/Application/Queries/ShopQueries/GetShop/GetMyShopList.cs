using AutoMapper;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using static Core.Application.Application.Queries.ShopQueries.GetShop.GetShop;

namespace Core.Application.Application.Queries.ShopQueries.GetShop
{
    public class GetMyShopList
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }

        public GetMyShopList(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ShopViewModel> Handle()
        {
            try
            {
                var shop = _context.Shops.Include(p => p.Product).Include(p => p.Category).Include(p => p.User).AsNoTracking().Where(p => p.UserId == id);
                if (shop is null) throw new InvalidOperationException("Listelenecek Liste Yoktur");

                var result = _mapper.Map<List<ShopViewModel>>(shop);

                return result;
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
          
        }
    }
}
