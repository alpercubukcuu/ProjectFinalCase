using AutoMapper;
using Core.Application.Application.Queries.ProductQueries.GetProduct;
using Core.Application.Application.Queries.UserQueries.GetUser;
using Core.Application.Dtos.CategoryDtos;
using Core.Application.Dtos.ProductDtos;
using Core.Application.Dtos.ShopDtos;
using Core.Application.Dtos.UserDtos;
using Core.Application.Enums;
using Core.Domain.Entities.Categories;
using Core.Domain.Entities.Products;
using Core.Domain.Entities.Shops;
using Core.Domain.Entities.Users;
using static Core.Application.Application.Queries.ShopQueries.GetShop.GetShop;

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

            CreateMap<Product, ProductsViewModel>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => ((CategoryEnum)src.CategoryId).ToString()));

            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductDto>();

            CreateMap<Shops , ShopViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(m => m.Category.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(m => m.User.Name))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(m => m.Product.Name));

            CreateMap<ShopDto, Shops>();
        }
    }
}
