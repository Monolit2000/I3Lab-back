using FluentResults;
using I3Lab.Doctors.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Domain.Doctors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.CreateDoctorCreationProposal
{
    public class CreateDoctorCreationProposalCommandHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<CreateDoctorCreationProposalCommand, Result<DoctorCreationProposalDto>>
    {
        public async Task<Result<DoctorCreationProposalDto>> Handle(CreateDoctorCreationProposalCommand request, CancellationToken cancellationToken)
        {
            var doctorCreationProposal = DoctorCreationProposal.CreateNew(
                DoctorName.Create(request.FirstName, request.LastName),
                Email.Create( request.Email),
                DoctorAvatar.Create( request.DoctorAvatar));

            await doctorCreationProposalRepository.AddAsync(doctorCreationProposal);

            var doctorCreationProposalDto = new DoctorCreationProposalDto(doctorCreationProposal.Id.Value);

            return doctorCreationProposalDto;
        }
    }
}
