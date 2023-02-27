using Core.Application.Application.Commands.UserCommand.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Queries.UserQueries.GetValidatorUser
{
    public class GetValidatorUser : AbstractValidator<CreateUserCommand>
    {
        public GetValidatorUser()
        {
            RuleFor(command => command.Model.Id)
                .NotNull();

        }
    }
}
