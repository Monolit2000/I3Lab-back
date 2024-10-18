using Microsoft.AspNetCore.SignalR;
using I3Lab.BuildingBlocks.Application.Cache;

namespace I3Lab.API.Modules.Treatments.TreatmentStageChats.Hubs
{

    public class ChatHub(IInMemoryCacheService cache) : Hub<ITreatmentChatClient>
    {
        public async Task JoinChat(string userName, string GroupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GroupId);

            await cache.SetAsync(Context.ConnectionId, GroupId);

            await Clients.Group(GroupId).ReceiveMessage("Admin", $"{userName} joined to chat");

        }

        public async Task SendMessage(string message)
        {
            var groupName = await cache.GetAsync<string>(Context.ConnectionId);

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
