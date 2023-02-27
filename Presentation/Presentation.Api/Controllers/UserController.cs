using AutoMapper;
using Core.Application.Application.Commands.UserCommand.CreateUser;
using Core.Application.Application.Queries.UserQueries.GetUser;
using Core.Application.Dtos.UserDtos;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;

        public UserController(ILogger<UserController> logger, DatabaseContext context, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            GetUsers queries = new GetUsers(_context, _mapper);
            queries.Handle();

            return Ok(queries);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDtos newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = newUser;
            command.Handle();

            return Ok();
        }

       
    }
}
