using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.Users.Application.Register;
using Microsoft.AspNetCore.Authorization;
using I3Lab.Works.Application.Treatments.CreateTreatment;
using I3Lab.API.Modules.Works.Work;
using I3Lab.API.Modules.Base;


namespace I3Lab.API.Modules.Treatments
{
    [Route("api/treatments")]
    [ApiController]
    public class TreatmentController : BaseController
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
            return HandleResult(await _mediator.Send(createTreatmentCommand));
        }
    }
}
