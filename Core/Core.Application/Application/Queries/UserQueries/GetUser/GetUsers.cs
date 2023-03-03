using AutoMapper;
using Core.Domain.Entities.Roles;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
            List<UserViewModel> vm = new();
            try
            {
                var userList = _context.Users.ToList();
                if (userList.Count() == 0)
                    throw new InvalidOperationException("Listelenecek bir kullanıcı bulunamadı!");

               vm = _mapper.Map<List<UserViewModel>>(userList);

                return vm;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
         
        }
    }

    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
      
    }
}
