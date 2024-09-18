using FluentResults;
using I3Lab.Doctors.Domain.DoctorCreationProposals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.GetAllDoctorCreationProposal
{
    public class GetAllDoctorCreationProposalQueryHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<GetAllDoctorCreationProposalQuery, Result>
    {
        public Task<Result> Handle(GetAllDoctorCreationProposalQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
