using FluentResults;
using I3Lab.Doctors.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Domain.Doctors;
using MediatR;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.CreateDoctorCreationProposal
{
    public class CreateDoctorCreationProposalCommandHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<CreateDoctorCreationProposalCommand, Result<DoctorCreationProposalDto>>
    {
        public async Task<Result<DoctorCreationProposalDto>> Handle(CreateDoctorCreationProposalCommand request, CancellationToken cancellationToken)
        {

            var email = Email.Create(request.Email);

            var exist = await doctorCreationProposalRepository.ExistByEmailAsync(email);
            if (exist)
                return Result.Fail($"Proposal with this email '{email}' already exist");

            var doctorCreationProposal = DoctorCreationProposal.CreateNew(
                DoctorName.Create(request.FirstName, request.LastName),
                email,
                PhoneNumber.Create(request.PhoneNumber),
                DoctorAvatar.Create( request.DoctorAvatar));

            await doctorCreationProposalRepository.AddAsync(doctorCreationProposal);

            var doctorCreationProposalDto = new DoctorCreationProposalDto(doctorCreationProposal.Id.Value);

            return doctorCreationProposalDto;
        }
    }
}
