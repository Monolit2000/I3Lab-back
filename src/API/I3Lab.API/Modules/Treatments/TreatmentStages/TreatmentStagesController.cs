using I3Lab.API.Modules.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace I3Lab.API.Modules.Treatments.Work
{
    [Route("api/treatmentStages")]
    [ApiController]
    public class TreatmentStagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TreatmentStagesController> _logger;

        public TreatmentStagesController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<TreatmentStagesController> logger)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

    }
}
