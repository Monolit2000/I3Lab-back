using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;

namespace I3Lab.Treatments.Application.WorkChats.AddMessage
{
    public class AddMessageCommandHendler(
        ITreatmentStageChatRepository workChatRepository) : IRequestHandler<AddMessageCommand, Result>
    {
        public async Task<Result> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var workChat = await workChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            if (workChat == null)
                return Result.Fail("TreatmentStageChat not found");

            var result = workChat.AddMessage(new MemberId(request.MemberId), request.Message);

            await workChatRepository.SaveChangesAsync();

            return result;
        }
    }
}
