using FluentResults;
using MediatR;

namespace I3Lab.Clinics.Application.DoctorCreationProposals.CreateDoctorCreationProposal
{
    public class CreateDoctorCreationProposalCommand : IRequest<Result<DoctorCreationProposalDto>>
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string DoctorAvatar { get; set; }

        public CreateDoctorCreationProposalCommand() { }

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
