using FluentResults;
using I3Lab.Administration.Domain.DoctorCreationProposals;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace I3Lab.Administration.Application.CreateDoctorCreationProposal
{
    public class CreateDoctorCreationProposalCommandHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository): IRequestHandler<CreateDoctorCreationProposalCommand>
    {
        public async Task Handle(CreateDoctorCreationProposalCommand request, CancellationToken cancellationToken)
        {
            var proposal = DoctorCreationProposal.Create(
                new DoctorCreationProposalId(request.ProposalId), 
                DoctorName.Create(request.FirstName, request.LastName),
                Email.Create(request.Email),
                PhoneNumber.Create(request.PhoneNumber),
                DoctorAvatar.Create(request.DoctorAvatar));

            await doctorCreationProposalRepository.AddAsync(proposal);

            await doctorCreationProposalRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
