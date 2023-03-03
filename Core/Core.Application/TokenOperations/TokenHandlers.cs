
using MovieStoreWebApi.TokenOperations.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Core.Domain.Entities.Users;
using Core.Domain.Entities.Roles;
using System.Security.Claims;

namespace MovieStoreWebApi.TokenOperations
{
    public class TokenHandlers
    {
        public  IConfiguration _configuration {get; set;}
        public TokenHandlers(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(User user,string role)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            tokenModel.Expiration = DateTime.Now.AddMinutes(15);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, role)
            };

            JwtSecurityToken securityToken = new JwtSecurityToken
            (
                claims : claims,
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires:tokenModel.Expiration,
                notBefore:DateTime.Now,
                signingCredentials : credentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //token yaratılıyor
            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;
            
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}