﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.Treatments.Application.TreatmentInvites.CreateTreatmentInvite;
using Microsoft.IdentityModel.Tokens;
using I3Lab.API.Modules.Base;
using I3Lab.Treatments.Application.TreatmentInvites.AcceptTreatmentInvite;
using I3Lab.Treatments.Application.TreatmentInvites.RejectTreatmentInvite;
using I3Lab.Treatments.Application.TreatmentInvites.GetAllTreatmentInvitesByTreatmentId;

namespace I3Lab.API.Modules.Treatments.TreatmentInvites
{
    [Route("api/treatments/treatmentInvites")]
    [ApiController]
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
        public async Task<IActionResult> AcceptTreatmentInvite(AcceptTreatmentInviteCommand acceptTreatmentInviteCommand)
        {
            return HandleResult(await _mediator.Send(acceptTreatmentInviteCommand));
        }

        [HttpPost("rejectTreatmentInvite")]
        public async Task<IActionResult> RejectTreatmentInvite(RejectTreatmentInviteCommand rejectTreatmentInviteCommand)
        {
            return HandleResult(await _mediator.Send(rejectTreatmentInviteCommand));
        }

        [HttpGet("GetAllTreatmentInvitesByTreatmentId")]
        public async Task<IActionResult> GetAllTreatmentInvitesByTreatmentId([FromQuery]GetAllTreatmentInvitesByTreatmentIdQuery getAllTreatmentInvitesByTreatmentIdQuery)
        {
            return HandleResult(await _mediator.Send(getAllTreatmentInvitesByTreatmentIdQuery));
        }

    }
}