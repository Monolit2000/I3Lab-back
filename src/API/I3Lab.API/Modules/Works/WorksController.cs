using I3Lab.API.Modules.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace I3Lab.API.Modules.Works
{
    [Route("api/works")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<WorksController> _logger;

        public WorksController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<WorksController> logger)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

    }
}
