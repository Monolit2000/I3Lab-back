using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.Works.Application.TreatmentInvites.CreateTreatmentInvite;
using Microsoft.IdentityModel.Tokens;
using I3Lab.API.Modules.Base;
using I3Lab.Works.Application.TreatmentInvites.AcceptTreatmentInvite;
using I3Lab.Works.Application.TreatmentInvites.RejectTreatmentInvite;

namespace I3Lab.API.Modules.Works.TreatmentInvites
{
    public class TreatmentInvitesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TreatmentInvitesController> _logger;

        public TreatmentInvitesController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<TreatmentInvitesController> logger)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [HttpPost("createTreatmentInvite")]
        public async Task<IActionResult> CreaeteTreatmentInvite(CreateTreatmentInviteCommand createTreatmentInviteCommand)
        {
            return HandleResult(await _mediator.Send(createTreatmentInviteCommand));
        }

        [HttpPost("acceptTreatmentInvite")]
        public async Task<IActionResult> CreaeteTreatmentInvite(AcceptTreatmentInviteCommand acceptTreatmentInviteCommand)
        {
            return HandleResult(await _mediator.Send(acceptTreatmentInviteCommand));
        }

        [HttpPost("rejectTreatmentInvite")]
        public async Task<IActionResult> RejectTreatmentInvite(RejectTreatmentInviteCommand rejectTreatmentInviteCommand)
        {
            return HandleResult(await _mediator.Send(rejectTreatmentInviteCommand));
        }
    }
}