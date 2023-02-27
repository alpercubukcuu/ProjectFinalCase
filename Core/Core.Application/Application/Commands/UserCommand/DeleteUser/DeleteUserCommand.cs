using AutoMapper;
using Core.Application.Dtos.UserDtos;
using Core.Domain.Entities.Users;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Application.Application.Commands.UserCommand.DeleteUser
{
    public class DeleteUserCommand
    {
        private readonly DatabaseContext _context;
        public int? Id { get; set; }

        public DeleteUserCommand(DatabaseContext context)
        {
            _context = context;
          
        }
        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == Id);
            if (user is null)
                throw new InvalidOperationException("Böyle bir kullanıcı bulanamadı.");
            
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
