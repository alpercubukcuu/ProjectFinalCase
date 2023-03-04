using AutoMapper;
using Core.Domain.Entities.Shops;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Application.Queries.ShopQueries.GetShop
{
    public class GetShop
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetShop(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ShopViewModel> Handle()
        {
            try
            {
                var shop = _context.Shops.Include(p => p.Product).Include(p => p.Category).Include(p => p.User).OrderBy(x => x.Id).AsNoTracking().ToList<Shops>();
                if (shop.Count == 0) throw new InvalidOperationException("Listelenecek Liste Yoktur");

                var result = _mapper.Map<List<ShopViewModel>>(shop);

                return result;
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        
        }


        public class ShopViewModel
        {
            public string Title { get; set;}
            public string Description { get; set;}
            public string Quantity { get; set; }
            public DateTime CreatedDate { get; set; }

            public string CategoryName { get; set; }
            public string UserName { get; set; }
            public string ProductName { get; set; }
        }
       
    }
}
