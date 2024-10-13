using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStageChats;

namespace I3Lab.Treatments.Application.TreatmentStageChats.AddMessage
{
    public class AddMessageCommandHendler(
        ITreatmentStageChatRepository treatmentStageChatRepository) : IRequestHandler<AddMessageCommand, Result>
    {
        public async Task<Result> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var treatmentStageChat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            if (treatmentStageChat == null)
                return Result.Fail("TreatmentStageChat not found");

            var result = treatmentStageChat.AddMessage(new MemberId(request.MemberId), request.Message);

            await treatmentStageChatRepository.SaveChangesAsync();

            return result;
        }
    }
}
