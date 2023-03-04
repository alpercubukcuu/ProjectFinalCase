using AutoMapper;
using Core.Application.Application.Queries.UserQueries.GetUser;
using Core.Domain.Entities.Categories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Queries.ProductQueries.GetProduct
{
    public class GetProducts
    {
        public ProductsViewModel Model { get; set; }
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public GetProducts(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ProductsViewModel> Handle()
        {
            List<ProductsViewModel> vm = new();
            var products = _context.Products.ToList();
            vm = _mapper.Map<List<ProductsViewModel>>(products);
            return vm;
        }
    }

    public class ProductsViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public string CategoryName { get; set; }
    }
}
