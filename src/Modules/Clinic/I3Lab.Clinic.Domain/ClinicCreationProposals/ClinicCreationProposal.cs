using I3Lab.BuildingBlocks.Domain;
using I3Lab.Clinics.Domain.ClinicCreationProposals;
using I3Lab.Clinics.Domain.ClinicCreationProposals.Events;

namespace I3Lab.Clinics.Domain.Clinics
{
    public class ClinicCreationProposal : Entity, IAggregateRoot
    {
        public ClinicCreationProposalId Id { get; private set; }
        public ClinicName ClinicName { get; private set; }
        public ClinicAddress Address { get; private set; }
        public ConfirmationStatus ConfirmationStatus { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private ClinicCreationProposal() { }

        private ClinicCreationProposal(
            ClinicName clinicName,
            ClinicAddress address)
        {
            Id = new ClinicCreationProposalId(Guid.NewGuid());
            ClinicName = clinicName;
            Address = address;
            ConfirmationStatus = ConfirmationStatus.Validation;
            CreatedAt = DateTime.UtcNow;

            AddDomainEvent(new ClinicCreationProposalCreatedDomainEvent(
                Id.Value,
                ClinicName.Value,
                Address.Value,
                CreatedAt));
        }

        public static ClinicCreationProposal CreateNew(ClinicName clinicName, ClinicAddress address)
            => new ClinicCreationProposal(clinicName, address);

        public Clinic CreateClinic()
        {
            return Clinic.Create(ClinicName, Address);
        }

        public void Confirm()
        {
            if (ConfirmationStatus != ConfirmationStatus.Validation)
                throw new InvalidOperationException("Proposal cannot be confirmed.");

            ConfirmationStatus = ConfirmationStatus.Confirmed;

            AddDomainEvent(new ClinicCreationProposalConfirmedDomainEvent(Id));
        }

        public void Reject()
        {
            if (ConfirmationStatus != ConfirmationStatus.Validation)
                throw new InvalidOperationException("Proposal cannot be rejected.");

            ConfirmationStatus = ConfirmationStatus.Rejected;

            AddDomainEvent(new ClinicCreationProposalRejectedDomainEvent(Id));
        }
    }
}
