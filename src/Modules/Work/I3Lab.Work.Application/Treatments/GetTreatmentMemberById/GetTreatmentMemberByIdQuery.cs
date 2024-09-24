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
    public class GetTreatmentMemberByIdQuery : IRequest<Result<List<TreatmentMemberDto>>>
    {
        public Guid TreatmentId { get; set; }

        public Guid TreatmentMemberId { get; set; }

        public GetTreatmentMemberByIdQuery()
        {
                
        }

        public GetTreatmentMemberByIdQuery(
            Guid treatmentId, 
            Guid treatmentMemberId)
        {
            TreatmentId = treatmentId;
            TreatmentMemberId = treatmentMemberId;
        }
    }
}
