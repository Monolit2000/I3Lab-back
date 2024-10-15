using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.DoctorCreationProposals.Events
{
    public class DoctorCreationProposalCreatedDomainEvent : DomainEventBase
    {
        public Guid ProposalId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string PhoneNumber { get; }

        public string DoctorAvatar { get; }

        public DateTime CreatedAt { get; }

        public DoctorCreationProposalCreatedDomainEvent(
            Guid proposalId,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string doctorAvatar,
            DateTime createdAt)
        {
            ProposalId = proposalId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DoctorAvatar = doctorAvatar;
            CreatedAt = createdAt;
        }
    }
}
