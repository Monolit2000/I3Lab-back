using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.Users.Application.Register;
using Microsoft.AspNetCore.Authorization;
using I3Lab.Treatments.Application.Treatments.CreateTreatment;
using I3Lab.API.Modules.Treatments.Work;
using I3Lab.API.Modules.Base;
using I3Lab.Treatments.Application.Treatments.FinishTreatment;
using I3Lab.Treatments.Application.Treatments.GetTreatmentById;
using I3Lab.Treatments.Application.Treatments.AddTreatmentMember;
using I3Lab.Treatments.Application.Treatments.RemoveMember;
using I3Lab.Treatments.Application.Treatments.GetTreatmentMembers;


namespace I3Lab.API.Modules.Treatments
{
    [Route("api/treatments")]
    [ApiController]
    public class TreatmentController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TreatmentStagesController> _logger;

        public TreatmentController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<TreatmentStagesController> logger)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }


        [HttpPost("сreateTreatment")]
        public async Task<IActionResult> CeateTreatment(CreateTreatmentCommand createTreatmentCommand)
            => HandleResult(await _mediator.Send(createTreatmentCommand));

        [HttpPost("finishTreatment")]
        public async Task<IActionResult> FinishTreatment(FinishTreatmentCommand finishTreatmentCommand)
            => HandleResult(await _mediator.Send(finishTreatmentCommand));
        

        [HttpGet("getTreatmentById")]
        public async Task<IActionResult> GetTreatmentById(GetTreatmentByIdQuery getTreatmentByIdQuery)
            => HandleResult(await _mediator.Send(getTreatmentByIdQuery));

        [HttpGet("getTreatmentMembers")]
        public async Task<IActionResult> GetTreatmentMembers(GetTreatmentMemberByIdQuery getTreatmentMembersQuery)
           => HandleResult(await _mediator.Send(getTreatmentMembersQuery));

        //[HttpPost("addTreatmentMember")]
        //public async Task<IActionResult> AddTreatmentMember(AddTreatmentMemberCommand addTreatmentMemberCommand) 
        //    => HandleResult(await _mediator.Send(addTreatmentMemberCommand));


        [HttpPost("removeTreatmentMember")]
        public async Task<IActionResult> AddTreatmentMember(RemoveTreatmentMemberCommand removeTreatmentMemberCommand) 
            => HandleResult(await _mediator.Send(removeTreatmentMemberCommand));
        
    }
}
