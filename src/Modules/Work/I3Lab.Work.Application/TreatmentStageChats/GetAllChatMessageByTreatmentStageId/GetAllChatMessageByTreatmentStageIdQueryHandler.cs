using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentStageChats.GetAllChatMessageByWorkId
{
    public class GetAllChatMessageByTreatmentStageIdQueryHandler(
        ITreatmentStageChatRepository _treatmentStageChatRepository) : IRequestHandler<GetAllChatMessageByTreatmentStageIdQuery, Result<List<ChatMessageDto>>>
    {
    
        public async Task<Result<List<ChatMessageDto>>> Handle(GetAllChatMessageByTreatmentStageIdQuery request, CancellationToken cancellationToken)
        {
            var treatmentStageChat = await _treatmentStageChatRepository
                .GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            if (treatmentStageChat == null)
                return Result.Fail<List<ChatMessageDto>>("Chat not found.");

            var chatMessageDtos = treatmentStageChat.Messages.Select(message => new ChatMessageDto
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
