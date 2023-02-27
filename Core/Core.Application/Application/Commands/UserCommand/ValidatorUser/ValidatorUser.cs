using Core.Application.Application.Commands.UserCommand.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Application.Commands.UserCommand.ValidatorUser
{
    public class ValidatorUser : AbstractValidator<CreateUserCommand>
    {
        public ValidatorUser()
        {
            RuleFor(command => command.Model.Id)
                .GreaterThan(0);           

            RuleFor(command => command.Model.Email)
                .MinimumLength(4);
        }
    }
}
