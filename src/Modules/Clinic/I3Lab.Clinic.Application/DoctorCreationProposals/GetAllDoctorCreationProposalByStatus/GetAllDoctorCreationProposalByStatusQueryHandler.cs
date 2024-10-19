using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.Doctors;
using I3Lab.Clinics.Domain.DoctorCreationProposals;

namespace I3Lab.Clinics.Application.DoctorCreationProposals.GetAllDoctorCreationProposalByStatus
{
    public class GetAllDoctorCreationProposalByStatusQueryHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<GetAllDoctorCreationProposalByStatusQuery, Result<List<DoctorCreationProposalDto>>>
    {
        public async Task<Result<List<DoctorCreationProposalDto>>> Handle(GetAllDoctorCreationProposalByStatusQuery request, CancellationToken cancellationToken)
        {
            var status = ConfirmationStatus.Create(request.Status);
            if (status.IsFailed)
                return Result.Fail("Invalid status");

            var proposals = await doctorCreationProposalRepository.GetAllByStatusAsync(status.Value, cancellationToken);

            if (proposals == null || !proposals.Any())
                return Result.Fail<List<DoctorCreationProposalDto>>("No pending proposals found");

            var proposalDtos = proposals.Select(proposal => new DoctorCreationProposalDto
            {
                Id = proposal.Id.Value,
                FirstName = proposal.Name.FirstName,
                LastName = proposal.Name.LastName,
                Email = proposal.Email.Value,
                PhoneNumber = proposal.PhoneNumber.Value,
                AvatarUrl = proposal.DoctorAvatar.Url,
                ConfirmationStatus = proposal.ConfirmationStatus.Value,
                CreatedAt = proposal.CreatedAt
            }).ToList();

            return Result.Ok(proposalDtos);
        }
    }
}
