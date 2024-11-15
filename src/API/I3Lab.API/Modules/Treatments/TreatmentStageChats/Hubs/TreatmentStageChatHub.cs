using Microsoft.AspNetCore.SignalR;
using I3Lab.BuildingBlocks.Application.Cache;
using MediatR;
using I3Lab.Treatments.Application.TreatmentStageChats.AddMessage;

namespace I3Lab.API.Modules.Treatments.TreatmentStageChats.Hubs
{
    public class TreatmentStageChatHub(
        IMediator mediator,
        IInMemoryCacheService cache) : Hub<ITreatmentChatClient>
    {
        public async Task JoinChat(string userName, string GroupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GroupId);

            await cache.SetAsync(Context.ConnectionId, GroupId);

            await Clients.Group(GroupId).ReceiveMessage("Admin", $"{userName} joined to chat");
        }

        public async Task SendMessage(Guid userId, Guid treatmentSageId, string message)
        {
            var groupName = await cache.GetAsync<string>(Context.ConnectionId);

            var result = await mediator.Send(new AddMessageCommand(treatmentSageId, userId, message));

            await Clients.Group(groupName).ReceiveMessage("UserName", message);
        }
    }

    public class UserConection
    {
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string ChatId { get; set; }
        public string Device { get; set; }
    }
}
