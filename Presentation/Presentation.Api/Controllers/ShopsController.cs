using AutoMapper;
using Core.Application.Application.Commands.ShopCommand.CreateShop;
using Core.Application.Application.Commands.ShopCommand.DeleteShop;
using Core.Application.Application.Commands.ShopCommand.UpdateShop;
using Core.Application.Application.Queries.ShopQueries.GetShop;
using Core.Application.Dtos.ShopDtos;
using Core.Application.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Presentation.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private IHelper _helper;
        public ShopsController(DatabaseContext context, IMapper mapper, IHelper helper)
        {
            _context = context;
            _mapper = mapper;
            _helper = helper;
        }

        [HttpGet]
        [Route("/AllGetShops"), Authorize(Roles = "Admin")] // Admin için 
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]       
        public IActionResult GetShops()
        {
            GetShop queries = new GetShop(_context, _mapper);
            var result = queries.Handle();

            return Ok(result);
        }

        [HttpGet]
        [Route("/GetMyShopList")] // Normal için
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]       
        public IActionResult GetMyShopList()
        {
            var identity = HttpContext.User.Identity;
            if (!identity.IsAuthenticated) throw new InvalidOperationException("Sisteme giriş bilgileriniz doğru değil");
            int userId = _helper.GetByUserId();

            GetMyShopList queries = new GetMyShopList(_context, _mapper);
            queries.id = userId;
            var result = queries.Handle();

            return Ok(result);
        }

        [HttpPost]
        [Route("/AddShop")]
        [EnableRateLimiting("Basic")]
        public IActionResult AddShop([FromBody] ShopDto shop)
        {
            var identity = HttpContext.User.Identity;
            if (!identity.IsAuthenticated) throw new InvalidOperationException("Sisteme giriş bilgileriniz doğru değil");

            int userId = _helper.GetByUserId();

            CreateShopCommand createShop = new CreateShopCommand(_context, _mapper);
            createShop.Model = shop;
            createShop.id = userId;
            var result = createShop.Handle();
            return Ok(result);
        }

        [HttpDelete]
        [Route("/DeleteShop")]
        [EnableRateLimiting("Basic")]
        public IActionResult DeleteShop(int id)
        {
            DeleteShopCommand deleteShop = new DeleteShopCommand(_context);
            deleteShop.id = id;
            var result = deleteShop.Handle();
            return Ok(result);
        }

        [HttpPut]
        [Route("/UpdateShop")]
        [EnableRateLimiting("Basic")]
        public IActionResult UpdateShop([FromBody] ShopDto shop , [FromQuery]int id)
        {
            UpdateShopCommand updateShop = new UpdateShopCommand(_context);
            updateShop.id = id;
            updateShop.Model = shop;
            var result = updateShop.Handle();
            return Ok(result);
        }
    }
}
