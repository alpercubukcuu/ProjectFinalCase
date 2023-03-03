using Core.Application.Application.Commands.CategoryCommand.CreateCategory;
using FluentValidation;


namespace Core.Application.Application.Commands.CategoryCommand.ValidatorCategory
{
    public class ValidatorCategory : AbstractValidator<CreateCategoryCommand>
    {
        public ValidatorCategory()
        {
            RuleFor(command => command.Model.Name)
                .NotEmpty();      
          
        }
    }
}
