using MediatR;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.Treatments.Application.Members.GetAllMembers;

namespace I3Lab.API.Modules.Treatments.Members
{
    [Route("api/v{apiVersion:apiVersion}/treatments/members")]
    [ApiController]
    public class MembersController : BaseController
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



        [HttpGet("getAllMembers")]
        public async Task<IActionResult> GetAllMembers()
            => Ok(await _mediator.Send(new GetAllMembersQuery()));

    }
}
