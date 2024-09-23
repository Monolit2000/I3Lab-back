using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace I3Lab.API.Modules.Treatments.Members
{
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<MembersController> _logger;

        public MembersController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<MembersController> logger)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }
    }
}
