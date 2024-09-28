using Microsoft.AspNetCore.Mvc;
using MediatR;
using OpenTelemetry.Metrics;
using System.Runtime.CompilerServices;
using I3Lab.Treatments.Application.Members.GetAllMembers;
using I3Lab.API.Modules.Base;

namespace I3Lab.API.Modules.Treatments.Members
{
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

        public async Task<IActionResult> GetAllMembers(GetAllMembersQuery getAllMembersQuery)
            => HandleResult(await _mediator.Send(getAllMembersQuery));

    }
}
