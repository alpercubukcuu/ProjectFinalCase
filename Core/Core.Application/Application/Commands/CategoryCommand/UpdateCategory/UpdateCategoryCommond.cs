using Core.Application.Dtos.CategoryDtos;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Commands.CategoryCommand.UpdateCategory
{
    public class UpdateCategoryCommond
    {
        private readonly DatabaseContext _context;
        public int id { get; set; }
        public CategoryDto Model { get; set; }
        public UpdateCategoryCommond(DatabaseContext context)
        {
            _context = context;
        }
        
        public string Handle()
        {
            string message = "Güncelleme işlemi basarılı";
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null) throw new InvalidOperationException("Bu id sahip kategori bulunmamaktadır."+ " - " + HttpStatusCode.NotModified);

            category.Name = Model.Name;
            _context.Categories.Update(category);
            _context.SaveChanges();

            return message;
        }
       
    }
}
