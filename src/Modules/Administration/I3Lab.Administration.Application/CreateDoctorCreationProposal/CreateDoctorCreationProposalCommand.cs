using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Application.CreateDoctorCreationProposal
{
    public class CreateDoctorCreationProposalCommand : IRequest
    {
        public Guid ProposalId { get; set; }
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string DoctorAvatar { get; set; }

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
