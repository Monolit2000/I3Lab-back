using MediatR;
using Asp.Versioning;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.API.Modules.Treatments.Treatments;
using I3Lab.Treatments.Application.Treatments.RemoveMember;
using I3Lab.Treatments.Application.Treatments.CreateTreatment;
using I3Lab.Treatments.Application.Treatments.GetAllTreatment;
using I3Lab.Treatments.Application.Treatments.FinishTreatment;
using I3Lab.Treatments.Application.Treatments.GetTreatmentById;
using I3Lab.Treatments.Application.Treatments.GetTreatmentMembers;
using I3Lab.Treatments.Application.Treatments.GetAllTreatmentsByPatient;
using I3Lab.Treatments.Application.Treatments.GetTreatmentInvitationLink;
using I3Lab.Treatments.Application.Treatments.GetAllTreatmentsByMemberId;
using I3Lab.Treatments.Application.Treatments.JoinToTreatmentByInvitationLink;

namespace I3Lab.API.Modules.Treatments
{
    [Route("api/v{apiVersion:apiVersion}/treatments")]
    [ApiController]
    [ApiVersion(1)]
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


        [HttpPost("finishTreatment")]
        public async Task<IActionResult> FinishTreatment(FinishTreatmentCommand finishTreatmentCommand)
            => HandleResult(await mediator.Send(finishTreatmentCommand));


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
        public async Task<IActionResult> GetAllTreatmentsByMemberId([FromQuery] GetAllTreatmentsByMemberIdRequest request)
            => HandleResult(await mediator.Send(new GetAllTreatmentsByMemberIdQuery() { UserId = request.MemberId }));
            

        [HttpPost("removeTreatmentMember")]
        public async Task<IActionResult> AddTreatmentMember(RemoveTreatmentMemberCommand removeTreatmentMemberCommand) 
            => HandleResult(await mediator.Send(removeTreatmentMemberCommand));


        [HttpGet("getTreatmentInvitationLink")]
        public async Task<IActionResult> GetTreatmentJoinLink([FromQuery] GetTreatmentInvitationLinkCommand getTreatmentJoinLinkCommand)
            => HandleResult(await mediator.Send(getTreatmentJoinLinkCommand));


        [HttpPost("joinToTreatmentByInvitationLink")]
        public async Task<IActionResult> JoinToTreatmentByInvitationLink(JoinToTreatmentByInvitationLinkCommand joinToTreatmentByInvitationLinkCommand)
            => HandleResult(await mediator.Send(joinToTreatmentByInvitationLinkCommand));
    }
}
