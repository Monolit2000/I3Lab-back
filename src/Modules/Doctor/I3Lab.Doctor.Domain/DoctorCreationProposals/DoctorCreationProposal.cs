using I3Lab.BuildingBlocks.Domain;
using I3Lab.Doctors.Domain.DoctorCreationProposals.Events;
using I3Lab.Doctors.Domain.Doctors;
using MassTransit.NewIdProviders;
using MassTransit.Testing;

namespace I3Lab.Doctors.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposal : Entity, IAggregateRoot
    {
        public DoctorCreationProposalId Id { get; }

        public DoctorName Name { get; private set; }
        
        public Email Email { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public ConfirmationStatus ConfirmationStatus { get; private set; }

        public DoctorAvatar DoctorAvatar { get; private set; }

        public DateTime CreatedAt { get; set; }

        private DoctorCreationProposal() { }

        private DoctorCreationProposal(
            DoctorName name,
            Email email,
            PhoneNumber phoneNumber,
            DoctorAvatar doctorAvatar)
        {
            Id = new DoctorCreationProposalId(Guid.NewGuid());
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            ConfirmationStatus = ConfirmationStatus.Validation;
            DoctorAvatar = doctorAvatar;
            CreatedAt = DateTime.UtcNow;

            AddDomainEvent(new DoctorCreationProposalCreatedDomainEvent(
                Id.Value,
                Name.FirstName,
                Name.LastName,
                Email.Value,
                PhoneNumber.Value,
                DoctorAvatar.Url,
                CreatedAt));
        }

        public static DoctorCreationProposal CreateNew(DoctorName name, Email email, PhoneNumber phoneNumber, DoctorAvatar doctorAvatar) 
            => new DoctorCreationProposal(name, email, phoneNumber, doctorAvatar);

        public Doctor CreateDoctor()
        {
            return Doctor.CreateBaseOnProposal(Name, Email, PhoneNumber, DoctorAvatar);
        }

        public void Confirm()
        {
            if (ConfirmationStatus != ConfirmationStatus.Validation)
                throw new InvalidOperationException("Proposal cannot be approved.");

            ConfirmationStatus = ConfirmationStatus.Confirmed;

            AddDomainEvent(new DoctorCreationProposalConfirmedDomainEvent(Id));
        }

        public void Reject()
        {
            if (ConfirmationStatus != ConfirmationStatus.Validation)
                throw new InvalidOperationException("Proposal cannot be rejected.");

            ConfirmationStatus = ConfirmationStatus.Rejected;

            AddDomainEvent(new DoctorCreationProposalRejectedDomainEvent(Id));
        }
    }
}
