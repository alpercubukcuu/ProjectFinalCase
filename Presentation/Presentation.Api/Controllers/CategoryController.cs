using AutoMapper;
using Core.Application.Application.Commands.CategoryCommand.CreateCategory;
using Core.Application.Application.Commands.CategoryCommand.DeleteCategory;
using Core.Application.Application.Commands.CategoryCommand.UpdateCategory;
using Core.Application.Application.Queries.CategoryQueries.GetCategory;
using Core.Application.Dtos.CategoryDtos;
using Infrastructure.Persistence.Context;
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

        [HttpDelete]
        [Route("/DeleteCategory")]
        public IActionResult DeleteCategory([FromQuery] int id)
        {
            DeleteCategoryCommond deleteCategory = new DeleteCategoryCommond(_context);
            deleteCategory.id = id;
            var result = deleteCategory.Handle();
            return Ok(result);
        }

        [HttpPatch]
        [Route("/UpdateCategory")]
        public IActionResult UpdateCategory([FromBody] CategoryDto category, [FromQuery] int id)
        {
            UpdateCategoryCommond updateCategory = new UpdateCategoryCommond(_context);
            updateCategory.id = id;
            updateCategory.Model = category;
            var result = updateCategory.Handle();
            return Ok(result);
        }


    }
}
