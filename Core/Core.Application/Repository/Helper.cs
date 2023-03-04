using Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Application.Repository
{
    public class Helper : IHelper
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public Helper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int GetByUserId()
        {
            return Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
