using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Users.Application.Login
{
    public class LoginCommand : IRequest<Result<LoginDto>>
    {
    }
}
