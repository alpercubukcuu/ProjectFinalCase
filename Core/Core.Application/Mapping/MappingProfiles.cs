using AutoMapper;
using Core.Application.Application.Queries.UserQueries.GetUser;
using Core.Application.Dtos.CategoryDtos;
using Core.Application.Dtos.UserDtos;
using Core.Domain.Entities.Categories;
using Core.Domain.Entities.Users;


namespace Core.Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserDtos, User>();

            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryDto>();

            CreateMap<User, UserViewModel>();

            CreateMap<UserViewModel, User>();
        }
    }
}
