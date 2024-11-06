using MediatR;
using Asp.Versioning;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.Treatments.Application.Treatments.CreateTreatment;
using I3Lab.Treatments.Application.Treatments.GetAllTreatment;
using I3Lab.Treatments.Application.Treatments.CancelTreatment;
using I3Lab.Treatments.Application.Treatments.FinishTreatment;
using I3Lab.Treatments.Application.Treatments.GetTreatmentById;
using I3Lab.Treatments.Application.Treatments.GetTreatmentMembers;
using I3Lab.Treatments.Application.Treatments.RemoveTreatmentMember;
using I3Lab.Treatments.Application.Treatments.GetAllTreatmentsByPatient;
using I3Lab.Treatments.Application.Treatments.GetTreatmentInvitationLink;
using I3Lab.Treatments.Application.Treatments.GetAllTreatmentsByMemberId;
using I3Lab.Treatments.Application.Treatments.JoinToTreatmentByInvitationLink;
using I3Lab.Treatments.Application.Treatments.SetTreatmentMemberAccessibilityTypeAsReadOnly;
using I3Lab.Treatments.Application.Treatments.SetTreatmentMemberAccessibilityTypeAsEdit;

namespace I3Lab.API.Modules.Treatments
{
    [ApiVersion(1)]
    [ApiVersion(2)]
    [ApiController]
    [Route("api/v{apiVersion:apiVersion}/treatments")]
    public class TreatmentController(
        IMediator mediator) : BaseController
    {

        [MapToApiVersion(1)]
        [HttpGet("getAllTreatment")]
        public async Task<IActionResult> GetAllTreatment()
            => HandleResult(await mediator.Send(new GetAllTreatmentQuery()));

        [HttpPost("сreateTreatment")]
        public async Task<IActionResult> CeateTreatment(CreateTreatmentCommand createTreatmentCommand)
            => HandleResult(await mediator.Send(createTreatmentCommand));

        [HttpPut("finishTreatment")]
        public async Task<IActionResult> FinishTreatment(FinishTreatmentCommand finishTreatmentCommand)
            => HandleResult(await mediator.Send(finishTreatmentCommand));    
        
        [HttpPut("сancelTreatment")]
        public async Task<IActionResult> FinishTreatment(CancelTreatmentCommand сancelTreatmentCommand)
            => HandleResult(await mediator.Send(сancelTreatmentCommand));

        [HttpGet("getTreatmentById")]
        public async Task<IActionResult> GetTreatmentById([FromQuery] GetTreatmentByIdQuery getTreatmentByIdQuery)
            => HandleResult(await mediator.Send(getTreatmentByIdQuery));

        [HttpGet("getTreatmentMemberById")]
        public async Task<IActionResult> GetTreatmentMembers([FromQuery] GetTreatmentMemberByIdQuery getTreatmentMembersQuery)
           => HandleResult(await mediator.Send(getTreatmentMembersQuery));

        [HttpGet("getTreatmentMembers")]
        public async Task<IActionResult> GetTreatmentMember([FromQuery] GetTreatmentMembersQuery getTreatmentMembersQuery)
            => HandleResult(await mediator.Send(getTreatmentMembersQuery));

        [HttpGet("getAllTreatmentsByPatient")]
        public async Task<IActionResult> GetAllTreatmentsByPatient([FromQuery]GetAllTreatmentsByPatientQuery getAllTreatmentsByPatientQuery)
            => HandleResult(await mediator.Send(getAllTreatmentsByPatientQuery));

        [HttpGet("getAllTreatmentsByMemberId")]
        public async Task<IActionResult> GetAllTreatmentsByMemberId([FromQuery] Guid MemberId)
            => HandleResult(await mediator.Send(new GetAllTreatmentsByMemberIdQuery() { UserId = MemberId }));

        [HttpPut("removeTreatmentMember")]
        public async Task<IActionResult> AddTreatmentMember(RemoveTreatmentMemberCommand removeTreatmentMemberCommand) 
            => HandleResult(await mediator.Send(removeTreatmentMemberCommand));

        [HttpGet("getTreatmentInvitationLink")]
        public async Task<IActionResult> GetTreatmentJoinLink([FromQuery] GetTreatmentInvitationLinkCommand getTreatmentJoinLinkCommand)
            => HandleResult(await mediator.Send(getTreatmentJoinLinkCommand));

        [HttpPut("joinToTreatmentByInvitationLink")]
        public async Task<IActionResult> JoinToTreatmentByInvitationLink(JoinToTreatmentByInvitationLinkCommand joinToTreatmentByInvitationLinkCommand)
            => HandleResult(await mediator.Send(joinToTreatmentByInvitationLinkCommand));

        [HttpPut("SetTreatmentMemberAccessibilityTypeAsReadOnly")]
        public async Task<IActionResult> SetTreatmentMemberAccessibilityTypeAsReadOnly(
            SetTreatmentMemberAccessibilityTypeAsReadOnlyCommand setTreatmentMemberAccessibilityTypeAsReadOnlyCommand)
            => HandleResult(await mediator.Send(setTreatmentMemberAccessibilityTypeAsReadOnlyCommand));

        [HttpPut("SetTreatmentMemberAccessibilityTypeAsEdit")]
        public async Task<IActionResult> SetTreatmentMemberAccessibilityTypeAsReadOnly(
            SetTreatmentMemberAccessibilityTypeAsEditCommand setTreatmentMemberAccessibilityTypeAsEditCommand)
            => HandleResult(await mediator.Send(setTreatmentMemberAccessibilityTypeAsEditCommand));
    }
}
