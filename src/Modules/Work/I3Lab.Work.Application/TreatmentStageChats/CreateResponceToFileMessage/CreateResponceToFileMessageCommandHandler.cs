using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStageChats;

namespace I3Lab.Treatments.Application.TreatmentStageChats.CreateResponceToFileMessage
{
    public class CreateResponceToFileMessageCommandHandler(
        ITreatmentFileRepository treatmentFileRepository,
        ITreatmentStageChatRepository treatmentStageChatRepository) : IRequestHandler<CreateResponceToFileMessageCommand, Result<ResponceToFileMessageDto>>
    {
        public async Task<Result<ResponceToFileMessageDto>> Handle(CreateResponceToFileMessageCommand request, CancellationToken cancellationToken)
        {
            var treatmentStageChat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            if (treatmentStageChat == null)
                return Result.Fail("TreatmentStageChat not found");

            var file = await treatmentFileRepository.GetByIdAsync(new TreatmentFileId(request.FileId));

            var result = treatmentStageChat.AddResponseToFileMessage(new MemberId(request.MemberId), file, request.Message);

            await treatmentStageChatRepository.SaveChangesAsync();

            return result;

        }
    }
}
