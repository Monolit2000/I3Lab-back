using I3Lab.API.Modules.Works;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.Users.Application.Register;
using Microsoft.AspNetCore.Authorization;
using I3Lab.Works.Application.Treatments.CreateTreatment;


namespace I3Lab.API.Modules.Treatment
{
    [Route("api/treatments")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<WorksController> _logger;

        public TreatmentController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<WorksController> logger)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }


        [HttpPost("сreateTreatment")]
        public async Task<IActionResult> Register(CreateTreatmentCommand createTreatmentCommand)
        {
            var responce = await _mediator.Send(createTreatmentCommand);

            return Ok(responce);
        }
    }
}
