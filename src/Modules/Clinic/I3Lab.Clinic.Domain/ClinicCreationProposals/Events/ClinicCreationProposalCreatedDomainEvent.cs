using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Clinics.Domain.ClinicCreationProposals.Events
{
    public class ClinicCreationProposalCreatedDomainEvent : DomainEventBase
    {
        public Guid ClinicCreationProposalId { get; }
        public string ClinicName { get; }
        public string ClinicAddress { get; }
        public DateTime CreatedAt { get; }

        public ClinicCreationProposalCreatedDomainEvent(
            Guid clinicCreationProposalId,
            string clinicName,
            string clinicAddress,
            DateTime createdAt)
        {
            ClinicCreationProposalId = clinicCreationProposalId;
            ClinicName = clinicName;
            ClinicAddress = clinicAddress;
            CreatedAt = createdAt;
        }
    }
}
