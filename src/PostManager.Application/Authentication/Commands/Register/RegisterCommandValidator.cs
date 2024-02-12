using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r=>r.Email).NotEmpty().MinimumLength(7);
            RuleFor(r => r.Username).NotEmpty().MinimumLength(7);
            RuleFor(r => r.Password).NotEmpty().MinimumLength(7);
        }
    }
}
