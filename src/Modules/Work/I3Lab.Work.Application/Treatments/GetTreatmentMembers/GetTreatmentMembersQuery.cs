using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.GetTreatmentMembers
{
    public class GetTreatmentMembersQuery : IRequest<Result<List<TreatmentMemberDto>>>
    {
        public Guid TreatmentId { get; set; }

        public Guid TreatmentMemberId { get; set; }

        public GetTreatmentMembersQuery()
        {
                
        }

        public GetTreatmentMembersQuery(
            Guid treatmentId, 
            Guid treatmentMemberId)
        {
            TreatmentId = treatmentId;
            TreatmentMemberId = treatmentMemberId;
        }
    }
}
