using I3Lab.BuildingBlocks.Domain;

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
