using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.ClinicCreationProposals.Events
{
    public class ClinicCreationProposalConfirmedDomainEvent : DomainEventBase
    {
        public ClinicCreationProposalId Id { get; }

        public ClinicCreationProposalConfirmedDomainEvent(ClinicCreationProposalId id)
        {
            Id = id;
        }
    }
}
