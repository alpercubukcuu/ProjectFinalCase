using AutoMapper;
using Core.Application.Dtos.UserDtos;
using Core.Domain.Entities.Users;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.DataProtection;
using MovieStoreWebApi.Chiper;


namespace Core.Application.Application.Commands.UserCommand.CreateUser
{
    public class CreateUserCommand
    {
        private readonly DatabaseContext _context;
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IMapper _mapper;
        public UserDtos Model { get; set; }
        public CreateUserCommand(DatabaseContext context, IMapper mapper, IDataProtectionProvider dataProtectionProvider)
        {
            _context = context;
            _mapper = mapper;
            _dataProtectionProvider = dataProtectionProvider;
        }
        public void Handle()
        {        
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email);

            if (user is not null)
                throw new InvalidOperationException("Bu email adresine kayıtlı kullanıcı vardır.");

            Chipers chipers = new Chipers(_dataProtectionProvider, Model.Email);
            Model.Password = chipers.Encrypt(Model.Password);
            Model.CreatedDate = DateTime.Now;

            user = _mapper.Map<User>(Model);

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
