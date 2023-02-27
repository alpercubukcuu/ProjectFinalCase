using AutoMapper;
using Core.Application.Dtos.UserDtos;
using Core.Domain.Entities.Users;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Application.Application.Commands.UserCommand.UpdateUser
{
    public class UpdateUserCommand
    {
        private readonly DatabaseContext _context;
        public UserDtos Model { get; set; }
        public int? Id { get; set; }
        public UpdateUserCommand(DatabaseContext context)
        {
            _context = context;          
        }
        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == Id);
            if (user is null)
                throw new InvalidOperationException("Böyle bir kullanıcı bulanamadı.");

            user.Name = Model.Name != default ? Model.Name : user.Name;
            user.Surname = Model.Surname != default ? Model.Surname : user.Surname;
            user.Password = Model.Password != default ? Model.Password : user.Password;
            user.Email = Model.Email != default ? Model.Email : user.Email;
          
            _context.SaveChanges();
        }
    }
}
