using FluentResults;
using I3Lab.Works.Domain.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Treatments.GetTreatmentMembers
{
    public class GetTreatmentMembersQuery : IRequest<Result<List<TreatmentMemberDto>>>
    {
        public Guid TreatmentId { get; set; }

        public GetTreatmentMembersQuery(Guid treatmentId)
        {
            TreatmentId = treatmentId;
        }
    }
}
