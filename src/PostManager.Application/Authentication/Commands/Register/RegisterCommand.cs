﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Authentication.Commands.Register
{
    public record RegisterCommand 
    (
      string Username,
      string Email,
      string Password
     
    ):IRequest;
}
