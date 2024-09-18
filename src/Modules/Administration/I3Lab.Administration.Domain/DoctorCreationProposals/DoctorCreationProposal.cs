using I3Lab.Administration.Domain.DoctorCreationProposals.Events;
using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Administration.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposal : Entity, IAggregateRoot
    {
        public DoctorCreationProposalId Id { get; }

        public DoctorName Name { get; private set; }

        public Email Email { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }
         
        public DoctorCreationProposalStatus ConfirmationStatus { get; private set; }

        public DoctorAvatar? DoctorAvatar { get; private set; }

        public DateTime CreatedAt { get; }

        private DoctorCreationProposal() { } //For EF Core 

        private DoctorCreationProposal(
            DoctorCreationProposalId doctorCreationProposalId,
            DoctorName name,
            Email email, 
            PhoneNumber phoneNumber, 
            DoctorAvatar doctorAvatar)
        {
            Id = doctorCreationProposalId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            ConfirmationStatus = DoctorCreationProposalStatus.Validation;
            DoctorAvatar = doctorAvatar;
            CreatedAt = DateTime.UtcNow;

            AddDomainEvent(new DoctorCreationProposalCreatedDomainEvent());

            //AddDomainEvent(new DoctorCreationProposalCreatedDomainEvent(
            //    Id.Value,
            //    Name.FirstName,
            //    Name.LastName,
            //    Email.Value,
            //    PhoneNumber.Value,
            //    DoctorAvatar.Url,
            //    CreatedAt));
        }

        public static DoctorCreationProposal Create(
            DoctorCreationProposalId doctorCreationProposalId,
            DoctorName name,
            Email email,
            PhoneNumber phoneNumber, 
            DoctorAvatar doctorAvatar)
            => new DoctorCreationProposal(
                doctorCreationProposalId,
                name, 
                email, 
                phoneNumber, 
                doctorAvatar);

        public void Confirm()
        {
            if (ConfirmationStatus != DoctorCreationProposalStatus.Validation)
                throw new InvalidOperationException("Proposal cannot be approved.");

            ConfirmationStatus = DoctorCreationProposalStatus.Confirmed;

            AddDomainEvent(new DoctorCreationProposalConfirmedDomainEvent(Id));
        }

        public void Reject()
        {
            if (ConfirmationStatus != DoctorCreationProposalStatus.Validation)
                throw new InvalidOperationException("Proposal cannot be rejected.");

            ConfirmationStatus = DoctorCreationProposalStatus.Rejected;
        }

    }
}
