using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.API.Modules.Base;
using I3Lab.Treatments.Application.TreatmentStageChats.AddMessage;
using I3Lab.Treatments.Application.TreatmentStageChats.RemoveChatMessage;
using I3Lab.Treatments.Application.TreatmentStageChats.EditChatMessage;
using I3Lab.Treatments.Application.TreatmentStageChats.GetAllChatMessageByWorkId;

namespace I3Lab.API.Modules.Treatments.TreatmentStageChats
{

    [Route("api/treatmentStageChats")]
    [ApiController]
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


        [HttpPost("addMessage")]
        public async Task<IActionResult> AddMessage(AddMessageCommand addMessageCommand)
        {
            return HandleResult(await _mediator.Send(addMessageCommand));

        }

        [HttpPost("removeChatMessageCommand")]
        public async Task<IActionResult> AddChatMember(RemoveChatMessageCommand removeChatMessageCommand)
        {
            return HandleResult(await _mediator.Send(removeChatMessageCommand));
        }


        [HttpPost("EditChatMessage")]
        public async Task<IActionResult> EditChatMessage(EditChatMessageCommand editChatMessageCommand)
        {
            return HandleResult(await _mediator.Send(editChatMessageCommand));
        }


        [HttpGet("getAllChatMessageByWorkId")]
        public async Task<IActionResult> GetAllChatMessageByWorkId([FromQuery] GetAllChatMessageByTreatmentStageIdQuery getAllChatMessageByWorkIdQuery)
        {
            return HandleResult(await _mediator.Send(getAllChatMessageByWorkIdQuery));
        }

    }
}
