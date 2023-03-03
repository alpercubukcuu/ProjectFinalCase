using AutoMapper;
using Core.Application.Application.Commands.CategoryCommand.CreateCategory;
using Core.Application.Application.Queries.CategoryQueries.GetCategory;
using Core.Application.Application.Queries.UserQueries.GetUser;
using Core.Application.Dtos.CategoryDtos;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CategoryController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("/AllCategories")]
        public IActionResult GetCategries()
        {
            GetCategory queries = new GetCategory(_context, _mapper);
            var result = queries.Handle();

            return Ok(result);
        }


        [HttpPost]
        [Route("/AddCategory")]
        public IActionResult AddCategory([FromBody] CategoryDto category)
        {
            CreateCategoryCommand createCategory = new CreateCategoryCommand(_context, _mapper);
            createCategory.Model = category;
            createCategory.Handle();
            
            return Ok();
        }

    }
}
