﻿using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Clinics.Domain.Clinics.Errors;
using I3Lab.Clinics.Domain.Clinics.Events;
using I3Lab.Clinics.Domain.Doctors;
using System.Net.Http.Headers;

namespace I3Lab.Clinics.Domain.Clinics
{
    public class Clinic : Entity, IAggregateRoot
    {
        public readonly List<ClinicDoctor> Doctors  = [];

        public ClinicId Id { get; private set; }
        public ClinicStatus Status { get; set; }
        public ClinicAddress Address { get; private set; }
        public ClinicName ClinicName { get; private set; } 

        public DateTime CreatedAt { get; private set; }

        private Clinic() { }// For EF Core    

        private Clinic(
            ClinicName clinicName,
            ClinicAddress address)
        {
            Id = new ClinicId(Guid.NewGuid());
            ClinicName = clinicName;
            Address = address;
            Status = ClinicStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }
        public static Clinic Create(ClinicName clinicName, ClinicAddress address) 
            => new Clinic(clinicName, address);

        public void UpdateInfo(
            ClinicName clinicName,
            ClinicAddress address)
        {
            ClinicName = clinicName;
            Address = address;
        }

        public void UpdateAddress(ClinicAddress newAddress)
        {
            Address = newAddress;
        }

        public void UpdateName(ClinicName newName)
        {
            ClinicName = newName;
        }

        public Result AddDoctor(DoctorId doctorId)
        {
            if (Doctors.Any(d => d.DoctorId == doctorId))
                return Result.Fail(ClinicDomainErrors.DoctorAlreadyAdded);

            Doctors.Add(ClinicDoctor.Create(this.Id, doctorId));
            AddDomainEvent(new ClinicDoctorAddedDomainEvent(this.Id, doctorId));
            return Result.Ok(); 
        }

        public void RemoveDoctor(DoctorId doctorId)
        {
            var doctor = Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
            if (doctor == null)
                throw new InvalidOperationException("Doctor does not exist in this clinic.");

            AddDomainEvent(new ClinicDoctorRemovedDomainEvent(this.Id, doctorId));
            Doctors.Remove(doctor);
        }
    }
}
