using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentResults;

namespace I3Lab.Clinics.Application.Clnics.CreateClnic
{
    public class CreateClnicCommand : IRequest<Result<ClnicDto>>
    {
    }
}
