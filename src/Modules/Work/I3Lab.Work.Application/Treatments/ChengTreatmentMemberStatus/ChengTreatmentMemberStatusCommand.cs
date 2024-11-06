using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.ChengTreatmentMemberStatus
{
    public class ChengTreatmentMemberStatusCommand : IRequest<Result>
    {
        public Guid TreatmentId { get; set; }
        public Guid TreatmentMemberId { get; set; }
        public string NewStatus { get; set; }

        public ChengTreatmentMemberStatusCommand(
           Guid treatmentId,
            Guid treatmentMemberId , 
            string newStatus)
        {
            TreatmentId = treatmentId;  
            TreatmentMemberId = treatmentMemberId ;
            NewStatus = newStatus;
        }
    }
}
