using I3Lab.Works.Application.WorkChats.AddMessage;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.Works.Application.WorkChats.AddChatMember;
using I3Lab.Works.Application.WorkChats.RemoveChatMessage;
using I3Lab.API.Modules.Base;
using I3Lab.Works.Application.WorkChats.EditChatMessage;
using I3Lab.Works.Application.WorkChats.GetAllChatMessageByWorkId;

namespace I3Lab.API.Modules.Works.WorkChats
{

    [Route("api/workChat")]
    [ApiController]
    public class WorkChatController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<WorkChatController> _logger;

        public WorkChatController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<WorkChatController> logger)
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
        public async Task<IActionResult> GetAllChatMessageByWorkId([FromQuery]GetAllChatMessageByWorkIdQuery getAllChatMessageByWorkIdQuery)
        {
            return HandleResult(await _mediator.Send(getAllChatMessageByWorkIdQuery));
        }

    }
}
