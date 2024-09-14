using I3Lab.Works.Application.WorkChats.AddMessage;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.Works.Application.WorkChats.AddChatMember;
using I3Lab.Works.Application.WorkChats.RemoveChatMessage;

namespace I3Lab.API.Modules.WorkChats
{

    [Route("api/workChat")]
    [ApiController]
    public class WorkChatController : ControllerBase
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
            var responce = await _mediator.Send(addMessageCommand);

            return Ok(responce);
        }

        [HttpPost("removeChatMessageCommand")]
        public async Task<IActionResult> AddChatMember(RemoveChatMessageCommand removeChatMessageCommand)
        {
            var responce = await _mediator.Send(removeChatMessageCommand);

            return Ok(responce);
        }

        [HttpPost("addChatMember")]
        public async Task<IActionResult> AddChatMember(AddChatMemberCommand addChatMemberCommand)
        {
            await _mediator.Send(addChatMemberCommand);

            return Ok();
        }

    }
}
