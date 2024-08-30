using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Administration.Domain.DoctorCreationProposals.Events
{
    public class DoctorCreationProposalConfirmedDomainEvent : DomainEventBase
    {
        public DoctorCreationProposalId DoctorCreationProposalId { get; set; }

        public DoctorCreationProposalConfirmedDomainEvent(DoctorCreationProposalId doctorCreationProposalId)
        {
            DoctorCreationProposalId = doctorCreationProposalId;
        }
    }
}
