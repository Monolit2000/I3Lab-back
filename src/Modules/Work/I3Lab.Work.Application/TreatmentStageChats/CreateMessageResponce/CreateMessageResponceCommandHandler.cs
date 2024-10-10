using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.Members;

namespace I3Lab.Treatments.Application.TreatmentStageChats.CreateMessageResponce
{
    public class CreateMessageResponceCommandHandler(
        ITreatmentStageChatRepository treatmentStageChatRepository) : IRequestHandler<CreateMessageResponceCommand, Result>
    {
        public async Task<Result> Handle(CreateMessageResponceCommand request, CancellationToken cancellationToken)
        {
            var chat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.TreatmentStageId));

            if (chat is null)
                return Result.Fail("Chat not faund");

            var result = chat.AddReplyToMessage(
                new MemberId(request.SenderId),
                new MessageId(request.MessageId),
                request.Message);

            if (result.IsFailed)
                return result;

            await treatmentStageChatRepository.SaveChangesAsync();

            return result;
        }
    }
}
