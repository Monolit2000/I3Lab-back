//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using I3Lab.API.Modules.Base;
//using I3Lab.Doctors.Application.Doctors.GetOllDoctors;
//using I3Lab.Doctors.Application.Doctors.GetDoctorById;

//namespace I3Lab.API.Modules.Doctors.Doctor
//{
//    [Route("api/v{apiVersion:apiVersion}/doctors")]
//    [ApiController]
//    public class DoctorsController : BaseController
//    {
//        private readonly IMediator _mediator;
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private readonly ILogger<DoctorsController> _logger;

//        public DoctorsController(
//            IMediator mediator,
//            IHttpContextAccessor httpContextAccessor,
//            ILogger<DoctorsController> logger)
//        {
//            _mediator = mediator;
//            _httpContextAccessor = httpContextAccessor;
//            _logger = logger;
//        }

//        [HttpGet("getAllDoctors")]
//        public async Task<IActionResult> GetAllDoctors() 
//            => HandleResult( await _mediator.Send(new GetAllDoctorsQuery()));


//        [HttpGet("getDoctorById")]
//        public async Task<IActionResult> GetDoctorById([FromQuery] GetDoctorByIdQuery getDoctorByIdQuery)
//           => HandleResult(await _mediator.Send(getDoctorByIdQuery));


//    }
//}
