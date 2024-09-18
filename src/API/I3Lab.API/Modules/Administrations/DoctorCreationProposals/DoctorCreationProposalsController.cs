using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.API.Modules.Base;
using I3Lab.Administration.Application.ConfirmDoctorCreationPropos;
using I3Lab.Administration.Application.GetDoctorCreationProposals;

namespace I3Lab.API.Modules.Administrations.DoctorCreationProposals
{
    [Route("api/administrations/doctorCreationProposals")]
    [ApiController]
    public class DoctorCreationProposalsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<DoctorCreationProposalsController> _logger;

        public DoctorCreationProposalsController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<DoctorCreationProposalsController> logger)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [HttpPost("getAllDoctorCreationProposals")]
        public async Task<IActionResult> GetAllDoctorCreationProposals(GetAllDoctorCreationProposalsQuery getAllDoctorCreationProposalsQuery)
        {
            return HandleResult(await _mediator.Send(getAllDoctorCreationProposalsQuery));
        }

        [HttpPost("confirmDoctorCreationProposal")]
        public async Task<IActionResult> ConfirmDoctorCreationProposal(ConfirmDoctorCreationProposCommand confirmDoctorCreationProposalCommand)
        {
            return HandleResult(await _mediator.Send(confirmDoctorCreationProposalCommand));
        }

        //[HttpPost("confirmDoctorCreationProposal")]
        //public async Task<IActionResult> ConfirmDoctorCreationProposal(ConfirmDoctorCreationProposCommand confirmDoctorCreationProposalCommand)
        //{
        //    return HandleResult(await _mediator.Send(confirmDoctorCreationProposalCommand));
        //}
    }
}
