using Core.Domain.Entities.Categories;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Commands.CategoryCommand.DeleteCategory
{
    public class DeleteCategoryCommond
    {
        private readonly DatabaseContext _context;
        public int id { get; set; }

        public DeleteCategoryCommond(DatabaseContext context)
        {
            _context = context;
        }
        public string Handle()
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == id);
            try
            {
                string message = "Silme işlemi basarılı";
                if (category is null)
                    throw new InvalidOperationException("Bu Id sahip kategori bulunmamaktadır..");

                _context.Categories.Remove(category);
                _context.SaveChanges();

                return message;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
           
        }
    }
}
