using I3Lab.Works.Application.WorkChats.AddMessage;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using I3Lab.Works.Application.WorkChats.AddChatMember;
using I3Lab.Works.Application.WorkChats.RemoveChatMessage;
using I3Lab.API.Modules.Base;

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

        //[HttpPost("addChatMember")]
        //public async Task<IActionResult> AddChatMember(AddChatMemberCommand addChatMemberCommand)
        //{
        //    await _mediator.Send(addChatMemberCommand);
        //    return Ok();
        //}

    }
}
