using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Treatments.GetTreatmentMembers
{
    public class GetTreatmentMembersQueryHandler : IRequestHandler<GetTreatmentMembersQuery, Result<List<TreatmentMemberDto>>>
    {
        public Task<Result<List<TreatmentMemberDto>>> Handle(GetTreatmentMembersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
