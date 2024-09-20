using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Domain.DoctorCreationProposals.Events
{
    public class DoctorCreationProposalRejectedDomainEvent : DomainEventBase
    {
        public DoctorCreationProposalId DoctorCreationProposalId { get; set; }

        public DoctorCreationProposalRejectedDomainEvent(DoctorCreationProposalId doctorCreationProposalId)
        {
            DoctorCreationProposalId = doctorCreationProposalId;
        }
    }
}
