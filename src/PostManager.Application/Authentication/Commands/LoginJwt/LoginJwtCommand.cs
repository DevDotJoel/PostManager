using ErrorOr;
using MediatR;
using PostManager.Application.Common.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Authentication.Commands.LoginJwt
{
    public record LoginJwtCommand
    (
        string Email,
        string Password
    ):IRequest<ErrorOr<AuthenticationResultModel>>;
}
