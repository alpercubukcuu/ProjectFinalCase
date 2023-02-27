using AutoMapper;
using Core.Application.Application.Queries.UserQueries.GetUser;
using Core.Application.Dtos.UserDtos;
using Core.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<UserDtos, User>();
            CreateMap<User, UserViewModel>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.RoleName));

        }
    }
}
