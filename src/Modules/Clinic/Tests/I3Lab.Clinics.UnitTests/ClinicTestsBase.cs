using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Doctors;
using I3Lab.Clinics.Domain.DoctorCreationProposals;

namespace I3Lab.Clinics.UnitTests
{
    public class ClinicTestsBase
    {
        protected class ClinicTestDataOptions
        {
            public DoctorName Name { get; set; }
            public Email Email { get; set; } 
            public PhoneNumber PhoneNumber { get; set; }
            public DoctorAvatar Avatar { get; set; } 
        }

        protected class ClinicTestData
        {
            public DoctorCreationProposal Proposal { get; }
            public Doctor Doctor { get; }

            public Clinic Clinic { get; }

            public ClinicTestData(
                DoctorCreationProposal proposal,
                Doctor doctor,
                Clinic clinic)
            {
                Proposal = proposal;
                Doctor = doctor;
                Clinic = clinic;
            }
        }

        protected ClinicTestData CreateClinicTestData(ClinicTestDataOptions options = null)
        {
            options ??= new ClinicTestDataOptions();

            // Create a new DoctorCreationProposal instance
            var proposal = DoctorCreationProposal.CreateNew(
                options.Name ??= DoctorName.Create("John", "Doe"),
                options.Email ??= Email.Create("johndoe@example.com"),
                options.PhoneNumber ??= PhoneNumber.Create("123456789"),
                options.Avatar ??= DoctorAvatar.Create("http://example.com/avatar.jpg")
            );

            var doctor = proposal.CreateDoctor();

            var clinic = Clinic.Create(
                ClinicName.Create("TestName"), 
                ClinicAddress.Create("TestAddres"));
        

            return new ClinicTestData(proposal, doctor, clinic);
        }
    }
}








//var rejectEvent = proposal.DomainEvents.OfType<DoctorCreationProposalRejectedDomainEvent>().SingleOrDefault();