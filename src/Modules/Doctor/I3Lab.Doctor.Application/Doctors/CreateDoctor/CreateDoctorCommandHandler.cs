using FluentResults;
using I3Lab.Doctors.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Domain.Doctors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.Doctors.CreateDoctor
{
    public class CreateDoctorCommandHandler(
        IDoctorRepository doctorRepository,
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<CreateDoctorCommand, Result<DoctorDto>>
    {
        public async Task<Result<DoctorDto>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var propose = await doctorCreationProposalRepository.GetByIdAsync(request.DoctorCreationProposalId);

            var doctor = propose.CreateDoctor();

            await doctorRepository.AddAsync(doctor);

            return new DoctorDto();
        }
    }
}
