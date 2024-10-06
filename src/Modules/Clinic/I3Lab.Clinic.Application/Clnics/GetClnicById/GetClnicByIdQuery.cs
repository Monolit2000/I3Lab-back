using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Application.Clnics.GetClnicById
{
    public class GetClnicByIdQuery : IRequest<Result<ClinicDto>>
    {
        public Guid ClinicId { get; set; }  
    }
}
