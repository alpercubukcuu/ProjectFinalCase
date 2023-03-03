using AutoMapper;
using Core.Application.Dtos.CategoryDtos;
using Core.Application.Dtos.UserDtos;
using Core.Domain.Entities.Categories;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.DataProtection;



namespace Core.Application.Application.Commands.CategoryCommand.CreateCategory
{
    public class CreateCategoryCommand
    {
        private readonly DatabaseContext _context;      
        private readonly IMapper _mapper;
        public CategoryDto Model { get; set; }

        public CreateCategoryCommand(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;           
        }

        public void Handle()
        {        
            var category = _context.Categories.SingleOrDefault(x => x.Name == Model.Name);

            if (category is not null)
                throw new InvalidOperationException("Böyle bir kategori zaten bulunmaktadır.");

            category = _mapper.Map<Category>(Model);
            category.CreatedDate = DateTime.Now;

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
