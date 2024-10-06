using MassTransit.Observables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.GetAllDoctorCreationProposal
{
    public class DoctorCreationProposalDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string DoctorAvatarUrl { get; set; }
        public string ConfirmationStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
