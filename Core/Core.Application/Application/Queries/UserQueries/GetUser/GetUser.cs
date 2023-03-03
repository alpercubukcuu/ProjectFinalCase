using Core.Application.Enums;
using Core.Domain.Entities.Users;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using MovieStoreWebApi.Chiper;
using MovieStoreWebApi.TokenOperations;
using MovieStoreWebApi.TokenOperations.Models;

namespace Core.Application.Application.Queries.UserQueries.GetUser
{
    public class GetUser
    {
        public CreateTokenModel Model { get; set; }
        private readonly DatabaseContext _context;      
        private IConfiguration _configuration;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public GetUser(DatabaseContext context, IConfiguration configuration, IDataProtectionProvider dataProtectionProvider)
        {
            _context = context;
            _configuration = configuration;
            _dataProtectionProvider = dataProtectionProvider;
        }
        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email);
            string role = ((RoleEnum)user.RoleId).ToString();

            Chipers chiper = new(_dataProtectionProvider, user.Email);           
            var decPassword = chiper.Decrypt(user.Password);

            if (Model.Password == decPassword)
            {
                //Create Token
                TokenHandlers handler = new TokenHandlers(_configuration);
                Token token = handler.CreateAccessToken(user, role);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(3);               

                return token;
            }
            else           
                throw new InvalidOperationException("Kullanıcı Adı - Şifre Hatalı!");
            
        }
    }

    public class CreateTokenModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
