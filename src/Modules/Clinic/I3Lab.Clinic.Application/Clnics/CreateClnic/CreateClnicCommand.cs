using MediatR;
using FluentResults;

namespace I3Lab.Clinics.Application.Clnics.CreateClnic
{
    public class CreateClnicCommand : IRequest<Result<ClnicDto>>
    {
        public string ClinicName { get; set; }  

        public string ClinicAddress { get; set; }   
    }
}
