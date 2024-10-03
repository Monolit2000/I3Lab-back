using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.Clnics;

namespace I3Lab.Clinics.Application.Clnics.CreateClnic
{
    public class CreateClnicCommand : IRequest<Result<ClnicDto>>
    {
        public string ClinicName { get; set; }  

        public string ClinicAddress { get; set; }   
    }
}
