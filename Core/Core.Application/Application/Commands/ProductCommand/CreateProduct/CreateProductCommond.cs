using AutoMapper;
using Core.Application.Application.Queries.ProductQueries.GetProduct;
using Core.Application.Dtos.ProductDtos;
using Core.Domain.Entities.Products;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Commands.ProductCommand.CreateProduct
{
    public class CreateProductCommond
    {
        public ProductDto Model { get; set; }
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateProductCommond(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public string Handle()
        {
            string message = "Ekleme işlemi başarılı";
            Model.CreatedDate = DateTime.Now;

            var products = _mapper.Map<Product>(Model);

            try
            {
                _context.Products.Add(products);
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
