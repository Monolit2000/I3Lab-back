﻿using I3Lab.BuildingBlocks.Domain;
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

        public ConfirmationStatus ConfirmationStatus { get; private set; }

        public DoctorAvatar DoctorAvatar { get; private set; }

        public DateTime CreatedAt { get; set; }

        private DoctorCreationProposal()
        {
                
        }

        private DoctorCreationProposal(
            DoctorName name,
            Email email,
            DoctorAvatar doctorAvatar)
        {
            Id = new DoctorCreationProposalId(Guid.NewGuid());
            Name = name;
            Email = email;
            ConfirmationStatus = ConfirmationStatus.Validation;
            DoctorAvatar = doctorAvatar;
            CreatedAt = DateTime.UtcNow;

            AddDomainEvent(new DoctorCreationProposalCreatedDomainEvent(Id.Value));
        }

        public Doctor CreateDoctor()
        {
            return Doctor.CreateBaseOnProposal(Name, Email, DoctorAvatar);
        }

        public static DoctorCreationProposal CreateNew(
            DoctorName name,
            Email email,
            DoctorAvatar doctorAvatar)
        {
            return new DoctorCreationProposal(
                name,
                email,
                doctorAvatar);
        }

        public void Approve()
        {
            if (ConfirmationStatus != ConfirmationStatus.Validation)
                throw new InvalidOperationException("Proposal cannot be approved.");

            ConfirmationStatus = ConfirmationStatus.Confirmed;

            AddDomainEvent(new DoctorCreationProposalApprovedDomainEvent());
        }

        public void Reject()
        {
            if (ConfirmationStatus != ConfirmationStatus.Validation)
                throw new InvalidOperationException("Proposal cannot be rejected.");

            ConfirmationStatus = ConfirmationStatus.Rejected;
        }
    }
}