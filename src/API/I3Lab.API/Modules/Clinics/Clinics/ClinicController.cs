﻿using MediatR;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.Doctors.Application.Doctors.GetDoctorById;
using I3Lab.Doctors.Application.Doctors.GetOllDoctors;
using I3Lab.Clinics.Application.Clnics.GetAllClnics;
using I3Lab.Clinics.Application.Clnics.CreateClnic;
using I3Lab.Clinics.Application.Clnics.GetClnicById;

namespace I3Lab.API.Modules.Clinics.Clinics
{
    [Route("api/v{apiVersion:apiVersion}/clinics")]
    [ApiController]
    public class ClinicController(
        IMediator mediator) : BaseController
    {

        [HttpPost("createClnic")]
        public async Task<IActionResult> CreateClnic(CreateClinicCommand createClnicCommand)
            => HandleResult(await mediator.Send(createClnicCommand));

        [HttpGet("getAllClinics")]
        public async Task<IActionResult> GetAllClinics()
          => HandleResult(await mediator.Send(new GetAllClnicsQuery()));


        [HttpGet("getClinicById")]
        public async Task<IActionResult> GetClnicById([FromQuery] GetClnicByIdQuery getDoctorByIdQuery)
           => HandleResult(await mediator.Send(getDoctorByIdQuery));
    }
}
