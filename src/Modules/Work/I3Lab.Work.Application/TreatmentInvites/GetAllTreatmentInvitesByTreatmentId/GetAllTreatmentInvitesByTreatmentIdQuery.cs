using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentInvites.GetAllTreatmentInvitesByTreatmentId
{
    public class GetAllTreatmentInvitesByTreatmentIdQuery : IRequest<Result<List<TreatmentInviteDto>>>
    {
        public Guid TreatmentId { get; set; }

        public GetAllTreatmentInvitesByTreatmentIdQuery()
        {
                
        }
        public GetAllTreatmentInvitesByTreatmentIdQuery(Guid treatmentId)
        {
            TreatmentId = treatmentId;
        }
    }
}
