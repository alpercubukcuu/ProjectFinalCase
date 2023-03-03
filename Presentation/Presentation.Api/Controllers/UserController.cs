using AutoMapper;
using Core.Application.Application.Commands.UserCommand.CreateUser;
using Core.Application.Application.Queries.UserQueries.GetUser;
using Core.Application.Dtos.UserDtos;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.DataProtection;
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
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public UserController(ILogger<UserController> logger, DatabaseContext context, IMapper mapper, IConfiguration configuration, IDataProtectionProvider dataProtectionProvider)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _dataProtectionProvider = dataProtectionProvider;
        }

        [HttpGet]
        [Route("/Users")]
        public IActionResult GetUsers()
        {
            GetUsers queries = new GetUsers(_context, _mapper);
            var result = queries.Handle();

            return Ok(result);
        }

        [HttpPost]
        [Route("/Register")]
        public IActionResult CreateUser(UserDtos user)
        {
            CreateUserCommand createUser = new CreateUserCommand(_context, _mapper, _dataProtectionProvider);
            createUser.Model = user;
            createUser.Handle();
            return Ok();
        }

        [HttpPost]
        [Route("/Login")]
        public IActionResult GetUser([FromBody] CreateTokenModel user)
        {
            GetUser users = new GetUser(_context, _configuration, _dataProtectionProvider);
            users.Model = user;
            var result = users.Handle();           
            return Ok(result);
        }     


    }
}
