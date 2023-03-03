using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet, Route("/GetMe"), Authorize(Roles = "Admin")]
        public IActionResult GetMe()
        {
            var username = "Alper";
            return Ok(username);
        }
       
    }
}
