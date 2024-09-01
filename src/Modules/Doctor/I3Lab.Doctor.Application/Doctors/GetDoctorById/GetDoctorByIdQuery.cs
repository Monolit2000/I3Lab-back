using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.Doctors.GetDoctorById
{
    public class GetDoctorByIdQuery : IRequest<Result<DoctorDto>>
    {
        public Guid DoctorId { get; set; }

        public GetDoctorByIdQuery(Guid doctorId)
        {
            DoctorId = doctorId;
        }
    }
}
