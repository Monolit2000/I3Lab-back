﻿using I3Lab.BuildingBlocks.Domain;
using I3Lab.Doctors.Domain.Clinics;
using MassTransit.Testing;
using FluentResults;
using I3Lab.Doctors.Domain.Doctors.Events;

namespace I3Lab.Doctors.Domain.Doctors
{
    public class Doctor : Entity, IAggregateRoot
    {
        public readonly List<Clinic> Clinics = [];
        public DoctorId Id { get; private set; }
        public DoctorName Name { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public DoctorAvatar DoctorAvatar { get; private set; }

        private Doctor() { }


        private Doctor(
            DoctorName name,
            Email email,
            PhoneNumber phoneNumber,
            DoctorAvatar doctorAvatar) 
        {
            Id = new DoctorId(Guid.NewGuid());
            Name = name;    
            Email = email;
            PhoneNumber = phoneNumber;
            DoctorAvatar = doctorAvatar;

            AddDomainEvent(new DoctorCreatedDomainEvent(Id.Value, Name.FirstName, Name.LastName)); 
        }

        public static Doctor CreateBaseOnProposal(
            DoctorName name, 
            Email email,
            PhoneNumber phoneNumber, 
            DoctorAvatar doctorAvatar) 
            => new Doctor(
                name, 
                email, 
                phoneNumber, 
                doctorAvatar);

        public Result AddClinic(Clinic clinic)
        {
            if (clinic == null)
                return Result.Fail("Clinic cannot be null.");

            if (Clinics.Any(c => c.Id == clinic.Id))
                return Result.Fail("Clinic is already associated with this doctor.");

            Clinics.Add(clinic);
            // Optionally add domain event
            // AddDomainEvent(new ClinicAddedToDoctorDomainEvent(this.Id, clinic.Id));
            return Result.Ok();

        }
            public void UpdateInfo(
            DoctorName name,
            Email email,
            PhoneNumber phoneNumber,
            DoctorAvatar doctorAvatar)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            DoctorAvatar = doctorAvatar;
        }
    }
}
