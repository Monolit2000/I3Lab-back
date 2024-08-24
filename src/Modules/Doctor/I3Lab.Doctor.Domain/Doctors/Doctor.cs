using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Works.Events;
using MassTransit.Testing;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Domain.Doctors
{
    public class Doctor : Entity, IAggregateRoot
    {
        public DoctorId Id { get; private set; }

        public DoctorName Name { get; private set; }

        public Email Email { get; private set; }

        //public ConfirmationStatus ConfirmationStatus { get; private set; }

        public DoctorAvatar DoctorAvatar { get; private set; }

        private Doctor()
        {
                
        }

        internal static Doctor CreateBaseOnProposal(
            DoctorName name,
            Email email,
            DoctorAvatar doctorAvatar)
        {
            return new Doctor(
                name,
                email, 
                doctorAvatar);
        }

        private Doctor(
            DoctorName name,
            Email email,
            DoctorAvatar doctorAvatar) 
        {
            Id = new DoctorId(Guid.NewGuid());
            Name = name;    
            Email = email;
            DoctorAvatar = doctorAvatar;
        }

         public void UpdateInfo(
            DoctorName name,
            Email email,
            DoctorAvatar doctorAvatar)
        {
            Name = name;
            Email = email;
            DoctorAvatar = doctorAvatar;
        }
    }
}
