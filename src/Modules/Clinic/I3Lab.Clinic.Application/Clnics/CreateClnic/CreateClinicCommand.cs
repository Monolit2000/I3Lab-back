using MediatR;
using FluentResults;

namespace I3Lab.Clinics.Application.Clnics.CreateClnic
{
    public class CreateClinicCommand : IRequest<Result<ClinicDto>>
    {
        public string ClinicName { get; set; }  

        public string ClinicAddress { get; set; }

        public CreateClinicCommand()
        {
            
        }

        public CreateClinicCommand(string clinicName, string clinicAddress)
        {
            ClinicName = clinicName;
            ClinicAddress = clinicAddress;
        }
    }
}
