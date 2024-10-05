using FluentResults;
using I3Lab.Treatments.Domain.TreatmentFils;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentStageChats.CreateResponceToFileChatMessage
{
    public class CreateResponceToFileChatMessageCommandHandler(
        ITreatmentStageChatRepository treatmentStageChatRepository,
        IBlobFileRepository blobFileRepository) : IRequestHandler<CreateResponceToFileChatMessageCommand, Result>
    {
        public async Task<Result> Handle(CreateResponceToFileChatMessageCommand request, CancellationToken cancellationToken)
        {
            var treatmentStageChat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.TreatmentStageChatId));

            var blobFile = await blobFileRepository.GetByIdAsync(new BlobFileId(request.FileId));

            treatmentStageChat.AddResponseToFileMessage(new MemberId(request.MemberId), blobFile, request.Message);

            return Result.Ok();
        }
    }
}
