using I3Lab.API.Modules.Base;
using I3Lab.API.Modules.Users;
using I3Lab.Treatments.Application.TreatmentStages.CloseTreatmentStage;
using I3Lab.Treatments.Application.TreatmentStages.GetTreatmentStageByTreatmentId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace I3Lab.API.Modules.Treatments.Work
{
    [Route("api/treatmentStages")]
    [ApiController]
    public class TreatmentStagesController(
        IMediator mediator) : BaseController
    {

        [HttpPost("closeTreatmentStage")]
        public async Task<IActionResult> CloseTreatmentStage(CloseTreatmentStageCommand closeTreatmentStageCommand)
            => HandleResult(await mediator.Send(closeTreatmentStageCommand));

        [HttpGet("getTreatmentStageByTreatmentId")]
        public async Task<IActionResult> GetTreatmentStageByTreatmentId([FromQuery] GetTreatmentStageByTreatmentIdQuery getTreatmentStageByTreatmentIdQuery)
            => HandleResult(await mediator.Send(getTreatmentStageByTreatmentIdQuery));
    }
}
