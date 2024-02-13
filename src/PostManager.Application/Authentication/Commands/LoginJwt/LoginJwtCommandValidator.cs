using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Authentication.Commands.LoginJwt
{
    public class LoginJwtCommandValidator : AbstractValidator<LoginJwtCommand>
    {
        public LoginJwtCommandValidator()
        {
            RuleFor(r => r.Email).NotEmpty().MinimumLength(7);
            RuleFor(r => r.Password).NotEmpty().MinimumLength(7);

        }
    }
}
