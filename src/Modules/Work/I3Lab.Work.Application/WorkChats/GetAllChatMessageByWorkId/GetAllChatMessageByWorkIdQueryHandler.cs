using FluentResults;
using I3Lab.Works.Domain.WorkChats;
using I3Lab.Works.Domain.Works;
using MediatR;

namespace I3Lab.Works.Application.WorkChats.GetAllChatMessageByWorkId
{
    public class GetAllChatMessageByWorkIdQueryHandler : IRequestHandler<GetAllChatMessageByWorkIdQuery, Result<List<ChatMessageDto>>>
    {
        private readonly IWorkChatRepository _workChatRepository;

        public GetAllChatMessageByWorkIdQueryHandler(IWorkChatRepository workChatRepository)
        {
            _workChatRepository = workChatRepository;
        }

        public async Task<Result<List<ChatMessageDto>>> Handle(GetAllChatMessageByWorkIdQuery request, CancellationToken cancellationToken)
        {
            var workChat = await _workChatRepository.GetByWorkIdAsync(new WorkId(request.WorkId));

            if (workChat == null)
            {
                return Result.Fail<List<ChatMessageDto>>("Chat not found.");
            }

            var chatMessageDtos = workChat.Messages.Select(message => new ChatMessageDto
            {
                Id = message.Id.Value,
                SenderId = message.SenderId.Value,
                MessageText = message.MessageText,
                SentDate = message.SentDate,
                EditDate = message.EditDate,
                IsEdited = message.IsEdited,
                RepliedToMessageId = message.RepliedToMessageId?.Value,
                IsResponseToFile = message.IsResponceToFileChatMessage()
            }).ToList();

            return Result.Ok(chatMessageDtos);
        }
    }

}
