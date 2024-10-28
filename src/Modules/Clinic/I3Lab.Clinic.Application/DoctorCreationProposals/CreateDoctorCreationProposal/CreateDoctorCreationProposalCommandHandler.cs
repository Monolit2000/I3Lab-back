using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.Doctors;
using I3Lab.Clinics.Domain.DoctorCreationProposals;

namespace I3Lab.Clinics.Application.DoctorCreationProposals.CreateDoctorCreationProposal
{
    public class CreateDoctorCreationProposalCommandHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<CreateDoctorCreationProposalCommand, Result<DoctorCreationProposalDto>>
    {
        public async Task<Result<DoctorCreationProposalDto>> Handle(CreateDoctorCreationProposalCommand request, CancellationToken cancellationToken)
        {
            var email = Email.Create(request.Email);

            var isExist = await doctorCreationProposalRepository.ExistByEmailAsync(email, cancellationToken);
            if (isExist)
                return Result.Fail(CreateDoctorCreationProposalError.ProposalAlreadyExist(email.Value));

            var doctorCreationProposal = DoctorCreationProposal.CreateNew(
                DoctorName.Create(request.FirstName, request.LastName),
                email,
                PhoneNumber.Create(request.PhoneNumber),
                DoctorAvatar.Create( request.DoctorAvatar));

            await doctorCreationProposalRepository.AddAsync(doctorCreationProposal, cancellationToken);

            await doctorCreationProposalRepository.SaveChangesAsync(cancellationToken);

            var doctorCreationProposalDto = new DoctorCreationProposalDto(doctorCreationProposal.Id.Value);

            return doctorCreationProposalDto;
        }
    }
}
