using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;

namespace I3Lab.Treatments.Application.WorkChats.GetAllChatMessageByWorkId
{
    public class GetAllChatMessageByWorkIdQueryHandler : IRequestHandler<GetAllChatMessageByWorkIdQuery, Result<List<ChatMessageDto>>>
    {
        private readonly ITreatmentStageChatRepository _workChatRepository;

        public GetAllChatMessageByWorkIdQueryHandler(ITreatmentStageChatRepository workChatRepository)
        {
            _workChatRepository = workChatRepository;
        }

        public async Task<Result<List<ChatMessageDto>>> Handle(GetAllChatMessageByWorkIdQuery request, CancellationToken cancellationToken)
        {
            var workChat = await _workChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

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
