using FluentResults;
using I3Lab.Treatments.Domain.TreatmentFils;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStageChats.CreateResponceToFileMessage
{
    public class CreateResponceToFileMessageCommandHandler(
        IBlobFileRepository blobFileRepository,
        ITreatmentStageChatRepository treatmentStageChatRepository) : IRequestHandler<CreateResponceToFileMessageCommand, Result<ResponceToFileMessageDto>>
    {
        public async Task<Result<ResponceToFileMessageDto>> Handle(CreateResponceToFileMessageCommand request, CancellationToken cancellationToken)
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
