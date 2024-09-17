using FluentResults;
using I3Lab.Administration.Application.GetDoctorCreationProposals;
using I3Lab.Administration.Domain.DoctorCreationProposals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Application.GetAllDoctorCreationProposals
{
    public class GetAllDoctorCreationProposalsQueryHandler : IRequestHandler<GetAllDoctorCreationProposalsQuery, Result<List<DoctorCreationProposDto>>>
    {
        private readonly IDoctorCreationProposalRepository _doctorCreationProposalRepository;

        public GetAllDoctorCreationProposalsQueryHandler(IDoctorCreationProposalRepository doctorCreationProposalRepository)
        {
            _doctorCreationProposalRepository = doctorCreationProposalRepository;
        }

        public async Task<Result<List<DoctorCreationProposDto>>> Handle(GetAllDoctorCreationProposalsQuery request, CancellationToken cancellationToken)
        {
            var doctorCreationProposals = await _doctorCreationProposalRepository.GetAllPendingAsync();

            var dtoList = doctorCreationProposals.Select(p => new DoctorCreationProposDto
            {
                Id = p.Id.Value, 
                FirstName = p.Name.FirstName,
                LastName = p.Name.LastName,
                Email = p.Email.Value,
                PhoneNumber = p.PhoneNumber.Value,
                ConfirmationStatus = p.ConfirmationStatus.Value, 
                CreatedAt = p.CreatedAt
            }).ToList();

            return Result.Ok(dtoList);
        }
    }

}
