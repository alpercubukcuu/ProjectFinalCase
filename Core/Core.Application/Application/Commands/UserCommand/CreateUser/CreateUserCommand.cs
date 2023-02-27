using AutoMapper;
using Core.Application.Dtos.UserDtos;
using Core.Domain.Entities.Users;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Application.Application.Commands.UserCommand.CreateUser
{
    public class CreateUserCommand
    {
        private readonly DatabaseContext _context;

        private readonly IMapper _mapper;
        public UserDtos Model { get; set; }
        public CreateUserCommand(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email);
            if (user is not null)
                throw new InvalidOperationException("Bu email adresine kayıtlı kullanıcı vardır.");

            user = _mapper.Map<User>(Model);

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
