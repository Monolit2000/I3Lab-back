using MediatR;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.Clinics.Application.Doctors.GetOllDoctors;
using I3Lab.Clinics.Application.Doctors.GetDoctorById;
using I3Lab.Clinics.Application.Doctors.GetAllDoctorsByClinicId;

namespace I3Lab.API.Modules.Clinics.Doctors
{
    [Route("api/v{apiVersion:apiVersion}/clinics/doctors")]
    [ApiController]
    public class DoctorsController(
        IMediator mediator) : BaseController
    {
        [HttpGet("getAllDoctors")]
        public async Task<IActionResult> GetAllDoctors()
            => HandleResult(await mediator.Send(new GetAllDoctorsQuery()));

        [HttpGet("getDoctorById")]
        public async Task<IActionResult> GetDoctorById([FromQuery] GetDoctorByIdQuery getDoctorByIdQuery)
           => HandleResult(await mediator.Send(getDoctorByIdQuery)); 

        [HttpGet("getAllDoctorsByClinicId")]
        public async Task<IActionResult> GetDoctorByClinicId([FromQuery] GetAllDoctorsByClinicIdQuery getAllDoctorsByClinicIdQuery)
           => HandleResult(await mediator.Send(getAllDoctorsByClinicIdQuery));
    }
}
