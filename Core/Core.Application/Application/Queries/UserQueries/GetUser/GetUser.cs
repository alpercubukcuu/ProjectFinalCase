using Infrastructure.Persistence.Context;
using Microsoft.Extensions.Configuration;


namespace Core.Application.Application.Queries.UserQueries.GetUser
{
    public class GetUser
    {
        public CreateTokenModel Model { get; set; }
        private readonly DatabaseContext _context;      
        private readonly IConfiguration _configuration;
        public GetUser(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;          
            _configuration = configuration;
        }
        public void Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            //if (user is not null)
            //{
            //    // Create Token
            //    TokenHandler handler = new TokenHandler();
            //    Token token = handler.CreateAccessToken(user);

            //    user.RefreshToken = token.RefreshToken;
            //    user.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(3);
            //    _context.SaveChanges();

            //    return token;
            //}
            //else
            //{
            //    throw new InvalidOperationException("Mail adresi hatalı!");
            //}
        }
    }

    public class CreateTokenModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
