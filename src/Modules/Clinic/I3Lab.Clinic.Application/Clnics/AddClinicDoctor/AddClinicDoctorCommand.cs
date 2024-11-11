using MediatR;
using FluentResults;

namespace I3Lab.Clinics.Application.Clnics.AddClinicDoctor
{
    public class AddClinicDoctorCommand : IRequest<Result>
    {
        public Guid ClinicId { get; set; }
        public Guid DoctorId { get; set; }

        public AddClinicDoctorCommand(
            Guid clinicId, 
            Guid doctorId)
        {
            ClinicId = clinicId;
            DoctorId = doctorId;
        }
    }
}
