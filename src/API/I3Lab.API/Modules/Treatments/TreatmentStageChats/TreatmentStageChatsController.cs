using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.API.Modules.Base;
using I3Lab.Treatments.Application.TreatmentStageChats.AddMessage;
using I3Lab.Treatments.Application.TreatmentStageChats.RemoveChatMessage;
using I3Lab.Treatments.Application.TreatmentStageChats.EditChatMessage;
using I3Lab.Treatments.Application.TreatmentStageChats.GetAllChatMessageByWorkId;
using Asp.Versioning;

namespace I3Lab.API.Modules.Treatments.TreatmentStageChats
{
    [Route("api/v{apiVersion:apiVersion}/treatmentStageChats")]
    [ApiController]
    [ApiVersion(1)]
    [ApiVersion(2)]

    public class TreatmentStageChatsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TreatmentStageChatsController> _logger;

        public TreatmentStageChatsController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<TreatmentStageChatsController> logger)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [MapToApiVersion(1)]
        [HttpPost("addMessage")]
        public async Task<IActionResult> AddMessage(AddMessageCommand addMessageCommand)
            => HandleResult(await _mediator.Send(addMessageCommand));


        [MapToApiVersion(2)]
        [HttpPost("CreateMessage")]
        public async Task<IActionResult> CreateMessage(AddMessageCommand addMessageCommand)
         => HandleResult(await _mediator.Send(addMessageCommand));


        [HttpPost("removeChatMessageCommand")]
        public async Task<IActionResult> AddChatMember(RemoveChatMessageCommand removeChatMessageCommand)
            => HandleResult(await _mediator.Send(removeChatMessageCommand));


        [HttpPut("EditChatMessage")]
        public async Task<IActionResult> EditChatMessage(EditChatMessageCommand editChatMessageCommand)
            => HandleResult(await _mediator.Send(editChatMessageCommand));


        [HttpGet("getAllChatMessageByWorkId")]
        public async Task<IActionResult> GetAllChatMessageByWorkId([FromQuery] GetAllChatMessageByTreatmentStageIdQuery getAllChatMessageByWorkIdQuery)
            => HandleResult(await _mediator.Send(getAllChatMessageByWorkIdQuery));
    }
}
