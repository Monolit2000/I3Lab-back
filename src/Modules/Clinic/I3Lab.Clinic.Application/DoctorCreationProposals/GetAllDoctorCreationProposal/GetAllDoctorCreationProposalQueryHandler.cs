using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.DoctorCreationProposals;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.GetAllDoctorCreationProposal
{
    public class GetAllDoctorCreationProposalQueryHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<GetAllDoctorCreationProposalQuery, Result<List<DoctorCreationProposalDto>>>
    {
        public async Task<Result<List<DoctorCreationProposalDto>>> Handle(GetAllDoctorCreationProposalQuery request, CancellationToken cancellationToken)
        {
            var proposals = await doctorCreationProposalRepository.GetAllAsync();

            if (proposals == null || !proposals.Any())
                return Result.Fail("No pending proposals found");

            var proposalDtos = proposals.Select(proposal => new DoctorCreationProposalDto
            {
                Id = proposal.Id.Value,
                Email = proposal.Email.Value,
                CreatedAt = proposal.CreatedAt,
                LastName = proposal.Name.LastName,
                FirstName = proposal.Name.FirstName,
                AvatarUrl = proposal.DoctorAvatar.Url,
                PhoneNumber = proposal.PhoneNumber.Value,
                ConfirmationStatus = proposal.ConfirmationStatus.Value,
            }).ToList();

            return Result.Ok(proposalDtos);
        }
    }
}
