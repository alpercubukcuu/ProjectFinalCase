using AutoMapper;
using Core.Application.Application.Commands.ProductCommand.CreateProduct;
using Core.Application.Application.Commands.ProductCommand.DeleteProduct;
using Core.Application.Application.Commands.ProductCommand.UpdateProduct;
using Core.Application.Application.Queries.ProductQueries.GetProduct;
using Core.Application.Dtos.ProductDtos;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public ProductController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/GetProducts")]
        public IActionResult GetProduct()
        {
            GetProducts products = new GetProducts(_context, _mapper);
            var result = products.Handle();
            return Ok(result);
        }

        [HttpPost]
        [Route("/AddProduct")]
        public IActionResult AddProduct([FromBody] ProductDto product)
        {
            CreateProductCommond productCommond = new CreateProductCommond(_context, _mapper);
            productCommond.Model = product;
            var result = productCommond.Handle();
            return Ok(result);
        }

        [HttpDelete]
        [Route("/DeleteProduct")]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            DeleteProductCommond deleteProduct = new DeleteProductCommond(_context);
            deleteProduct.id = id;
            var result = deleteProduct.Handle();
            return Ok(result);
        }

        [HttpPut]
        [Route("/UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] ProductDto product, [FromQuery] int id)
        {
            UpdateProductCommond updateProduct = new UpdateProductCommond(_context);
            updateProduct.id = id;
            updateProduct.Model = product;
            var result = updateProduct.Handle();
            return Ok(result);
        }
    }
}
