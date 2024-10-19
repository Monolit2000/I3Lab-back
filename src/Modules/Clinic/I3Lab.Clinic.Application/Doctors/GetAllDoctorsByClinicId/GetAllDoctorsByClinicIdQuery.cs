using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Application.Doctors.GetAllDoctorsByClinicId
{
    public class GetAllDoctorsByClinicIdQuery : IRequest<Result<List<DoctorDto>>>
    {
        public Guid ClinicId { get; set; }  
    }
}
