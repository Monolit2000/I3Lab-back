using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Application.GetAllDoctorCreationProposals
{
    public class DoctorCreationProposDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ConfirmationStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
