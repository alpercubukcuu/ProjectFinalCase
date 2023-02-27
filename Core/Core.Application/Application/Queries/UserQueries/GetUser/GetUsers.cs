using AutoMapper;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Queries.UserQueries.GetUser
{
    public class GetUsers
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public GetUsers(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<UserViewModel> Handle()
        {
            var userList = _context.Users.Include(x => x.Role).OrderBy(x => x.Id).ToList();
            if (userList.Count() == 0)
                throw new InvalidOperationException("Listelenecek bir kullanıcı bulunamadı!");

            List<UserViewModel> vm = _mapper.Map<List<UserViewModel>>(userList);

            return vm;
        }
    }

    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }      
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
