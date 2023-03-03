using AutoMapper;
using Core.Application.Application.Queries.UserQueries.GetUser;
using Core.Application.Dtos.CategoryDtos;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc;

namespace Core.Application.Application.Queries.CategoryQueries.GetCategory
{
    public  class GetCategory
    {      
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetCategory(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CategoryDto> Handle()
        {
            List<CategoryDto> dt = new();

            var categories = _context.Categories.ToList();
            dt = _mapper.Map<List<CategoryDto>>(categories);

            return dt;
        }
    }
}
