﻿using MediatR;
using FluentResults;
using I3Lab.Doctors.Domain.DoctorCreationProposals;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.GetAllDoctorCreationProposal
{
    public class GetAllDoctorCreationProposalQueryHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<GetAllDoctorCreationProposalQuery, Result<List<DoctorCreationProposalDto>>>
    {
        public async Task<Result<List<DoctorCreationProposalDto>>> Handle(GetAllDoctorCreationProposalQuery request, CancellationToken cancellationToken)
        {
            var proposals = await doctorCreationProposalRepository.GetAllAsync();

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
                ConfirmationStatus = proposal.ConfirmationStatus.ToString(),
                CreatedAt = proposal.CreatedAt
            }).ToList();

            return Result.Ok(proposalDtos);
        }
    }
}
