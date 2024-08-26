using FluentResults;
using I3Lab.Doctors.Domain.Doctors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.CreateDoctorCreationProposal
{
    public class CreateDoctorCreationProposalCommand : IRequest<Result<DoctorCreationProposalDto>>
    {
        public Guid UserId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string PhoneNumber { get; }

        public string DoctorAvatar { get; }

        public CreateDoctorCreationProposalCommand(
            Guid userId,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string doctorAvatar)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DoctorAvatar = doctorAvatar;
        }
    }
}
